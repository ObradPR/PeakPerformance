import { Component, OnInit, output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';

import { InputMaskModule } from 'primeng/inputmask';
import { CalendarModule } from 'primeng/calendar';
import { PasswordModule } from 'primeng/password';
import { DividerModule } from 'primeng/divider';

import { Constants } from '../../../constants';
import * as validators from '../../../validators';
import { ISignupDto } from '../../../_generated/interfaces';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [
    CommonModule,
    InputMaskModule,
    CalendarModule,
    PasswordModule,
    DividerModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss',
  providers: [DatePipe],
})
export class SignUpComponent implements OnInit {
  showSigninFormEvent = output<string>();
  signupForm: FormGroup = this.fb.group({});
  signupErrors: string[] = [];

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  private initializeForm() {
    this.signupForm = this.fb.group({
      firstName: [
        '',
        [
          Validators.required,
          Validators.maxLength(20),
          Validators.minLength(2),
        ],
      ],
      middleName: [''],
      lastName: [
        '',
        [
          Validators.required,
          Validators.maxLength(30),
          Validators.minLength(2),
        ],
      ],
      email: [
        '',
        [Validators.required, Validators.email, Validators.maxLength(100)],
      ],
      phoneNumber: [
        '',
        [Validators.required, Validators.pattern(Constants.REGEX_PHONE_NUMBER)],
      ],
      dateOfBirth: [
        '',
        [Validators.required, validators.minimumAgeValidator(18)],
      ],
      username: ['', [Validators.required]],
      password: [
        '',
        [Validators.required, Validators.pattern(Constants.REGEX_PASSWORD)],
      ],
      confirmPassword: [
        '',
        [
          Validators.required,
          validators.matchValues('password', 'confirmPassword'),
        ],
      ],
    });
  }

  onShowSignin() {
    this.showSigninFormEvent.emit(Constants.ROUTE_SIGN_IN);
  }

  async onSignUp() {
    if (this.signupForm.invalid) return;

    const signupUser: ISignupDto = this.signupForm.value;

    try {
      await this.authService.signup(signupUser).toResult();
    } catch (ex) {
      const errors: string[] = (ex as HttpErrorResponse).error.error.user;
      this.signupErrors = errors;
      console.log(this.signupErrors);
      throw ex;
    } finally {
      // this.pageLoader.hideLoader();
    }
  }
}
