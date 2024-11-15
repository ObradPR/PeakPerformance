import { Component, input, OnInit, output } from '@angular/core';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';
import { InputOtpModule } from 'primeng/inputotp';
import {
  ISignupDto,
  IValidateUserCodeDto,
  IValidateUserDto,
} from '../../../_generated/interfaces';
import { AuthService } from '../../../services/auth.service';
import { ToastService } from '../../../services/toast.service';
import { LoaderService } from '../../../services/loader.service';
import { SectionLoaderComponent } from '../../../components/section-loader/section-loader.component';

@Component({
  selector: 'app-code-verification',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, InputOtpModule, SectionLoaderComponent],
  templateUrl: './code-verification.component.html',
  styleUrl: './code-verification.component.scss',
})
export class CodeVerificationComponent implements OnInit {
  signupUser = input<ISignupDto | undefined>();
  passwordRecoveryUser = input<IValidateUserDto | undefined>();
  showPasswordRecovery = output<IValidateUserDto>();
  codeValue: string = '';

  constructor(
    private authService: AuthService,
    private toastService: ToastService,
    public loaderService: LoaderService
  ) { }

  ngOnInit(): void { }

  async onCodeVerify() {
    this.loaderService.showSectionLoader();

    if (this.signupUser()) {
      try {
        this.signupUser()!.verificationCode = +this.codeValue;
        await this.authService.signup(this.signupUser()!).toResult();
        this.toastService.showGeneralSuccess();
      } catch (ex) {
        throw ex;
      } finally {
        this.loaderService.hideSectionLoader();
      }
    } else if (this.passwordRecoveryUser()) {
      const validateCode: IValidateUserCodeDto = {
        email: this.passwordRecoveryUser()?.email!,
        verifyCode: +this.codeValue,
      };

      try {
        await this.authService.validateCode(validateCode).toResult();
        this.toastService.showSuccess(
          'Verified',
          'You can proceed with changing your password.'
        );

        this.showPasswordRecovery.emit(this.passwordRecoveryUser()!);
      } catch (ex) {
        throw ex;
      } finally {
        this.loaderService.hideSectionLoader();
      }
    }
  }

  async onResendCode() {
    const validateUser: IValidateUserDto = {
      username: this.signupUser()!.username,
      email: this.signupUser()!.email,
    };

    try {
      await this.authService.validateEmail(validateUser).toResult();
    } catch (ex) {
      throw ex;
    } finally {
      // this.pageLoader.hideLoader();
    }
  }
}
