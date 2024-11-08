import { CommonModule } from '@angular/common';
import { Component, OnInit, output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { PasswordModule } from 'primeng/password';
import { TooltipModule } from 'primeng/tooltip';
import { ISigninDto } from '../../../_generated/interfaces';
import { Constants, RouteConstants } from '../../../constants';
import { AuthService } from '../../../services/auth.service';
import { ToastService } from '../../../services/toast.service';

@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PasswordModule,
    TooltipModule,
  ],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss',
})
export class SignInComponent implements OnInit {
  showSignupFormEvent = output<string>();
  showPasswordRecoveryEvent = output<void>();
  signinForm: FormGroup = this.fb.group({});

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private toastService: ToastService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  private initializeForm() {
    this.signinForm = this.fb.group({
      username: ['', Validators.required],
      password: [
        '',
        [Validators.required, Validators.pattern(Constants.REGEX_PASSWORD)],
      ],
    });
  }

  onShowSignup() {
    this.showSignupFormEvent.emit(RouteConstants.ROUTE_SIGN_UP);
  }

  onShowPasswordRecovery() {
    this.showPasswordRecoveryEvent.emit();
  }

  async onSignin() {
    if (this.signinForm.invalid) {
      this.toastService.showFormError();
      return;
    }

    const signinUser: ISigninDto = this.signinForm.value;

    try {
      await this.authService.signin(signinUser).toResult();
      this.toastService.showSuccess('Success', 'Successfully signed in.');
    } catch (ex) {
      throw ex;
    } finally {
      // this.pageLoader.hideLoader()
    }
  }
}
