import { CommonModule } from '@angular/common';
import { Component, OnInit, output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { DividerModule } from 'primeng/divider';
import { InputMaskModule } from 'primeng/inputmask';
import { PasswordModule } from 'primeng/password';
import { TooltipModule } from 'primeng/tooltip';
import { ISignupDto, IValidateUserDto } from '../../../_generated/interfaces';
import { Constants } from '../../../constants';
import { AuthService } from '../../../services/auth.service';
import { ToastService } from '../../../services/toast.service';
import * as validators from '../../../validators';

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
    TooltipModule,
  ],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss',
})
export class SignUpComponent implements OnInit {
  showSigninFormEvent = output<string>();
  showCodeVerifyEvent = output<ISignupDto>();
  signupForm: FormGroup = this.fb.group({});

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private toastService: ToastService
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
      middleName: [null],
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

  async onSignup() {
    if (this.signupForm.invalid) return;

    const signupUser: ISignupDto = this.signupForm.value;

    const validateUser: IValidateUserDto = {
      username: signupUser.username,
      email: signupUser.email,
    };

    try {
      await this.authService.validateEmail(validateUser).toResult();
      this.showCodeVerifyEvent.emit(signupUser);
    } catch (ex) {
      throw ex;
    } finally {
      // this.pageLoader.hideLoader();
    }
  }
}
