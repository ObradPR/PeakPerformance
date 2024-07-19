import { CommonModule } from '@angular/common';
import { Component, input, OnInit, output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { DividerModule } from 'primeng/divider';
import { InputMaskModule } from 'primeng/inputmask';
import { PasswordModule } from 'primeng/password';
import { TooltipModule } from 'primeng/tooltip';
import {
  IChangePasswordDto,
  IValidateUserDto,
} from '../../../_generated/interfaces';
import { Constants } from '../../../constants';
import { AuthService } from '../../../services/auth.service';
import { ToastService } from '../../../services/toast.service';
import * as validators from '../../../validators';

@Component({
  selector: 'app-password-recovery',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TooltipModule,
    InputMaskModule,
    PasswordModule,
    DividerModule,
  ],
  templateUrl: './password-recovery.component.html',
  styleUrl: './password-recovery.component.scss',
})
export class PasswordRecoveryComponent implements OnInit {
  backToSigninEvent = output<void>();
  showCodeVerifyEvent = output<IValidateUserDto>();
  isChangePassword = input<boolean>();
  passwordRecoveryUser = input<IValidateUserDto | undefined>();
  passwordRecoveryForm: FormGroup = this.fb.group({});
  passwordChangeForm: FormGroup = this.fb.group({});

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private toastService: ToastService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  private initializeForm() {
    this.passwordRecoveryForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });

    this.passwordChangeForm = this.fb.group({
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

  async onPasswordRecovery() {
    if (this.passwordRecoveryForm.invalid) return;

    const validateUser: IValidateUserDto = {
      username: this.passwordRecoveryForm.value.username,
      email: this.passwordRecoveryForm.value.email,
    };

    try {
      await this.authService.validateUser(validateUser).toResult();
      this.showCodeVerifyEvent.emit(validateUser);
    } catch (ex) {
      throw ex;
    } finally {
      // this.pageLoader.hideLoader();
    }
  }

  onBackToSignin() {
    this.backToSigninEvent.emit();
  }

  async onPasswordChange() {
    if (this.passwordChangeForm.invalid) return;

    const user: IChangePasswordDto = {
      username: this.passwordRecoveryUser()?.username!,
      email: this.passwordRecoveryUser()?.email!,
      password: this.passwordChangeForm.value.password,
      confirmPassword: this.passwordChangeForm.value.confirmPassword,
    };

    try {
      await this.authService.changePassword(user).toResult();
      this.toastService.showSuccess(
        'Success',
        'Successfully changed password.'
      );

      this.onBackToSignin();
    } catch (ex) {
      throw ex;
    } finally {
      // this.pageLoader.hideLoader();
    }
  }
}
