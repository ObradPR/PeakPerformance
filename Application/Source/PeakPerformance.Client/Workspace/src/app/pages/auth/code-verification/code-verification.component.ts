import { Component, input, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { InputOtpModule } from 'primeng/inputotp';
import { AuthService } from '../../../services/auth.service';
import { ToastService } from '../../../services/toast.service';
import { ISignupDto } from '../../../_generated/interfaces';

@Component({
  selector: 'app-code-verification',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, InputOtpModule],
  templateUrl: './code-verification.component.html',
  styleUrl: './code-verification.component.scss',
})
export class CodeVerificationComponent implements OnInit {
  signupUser = input<ISignupDto>();
  codeValue: string = '';

  constructor(
    private authService: AuthService,
    private toastService: ToastService
  ) {}

  ngOnInit(): void {}

  async onCodeVerify() {
    if (this.signupUser()) {
      try {
        this.signupUser()!.verifyCode = +this.codeValue;
        await this.authService.signup(this.signupUser()!).toResult();
        this.toastService.showSuccess('Success', 'Successfully signed up.');
      } catch (ex) {
        throw ex;
      } finally {
        // this.pageLoader.hideLoader();
      }
    }
  }

  async onResendCode() {
    try {
      await this.authService
        .validateEmail(this.signupUser()!.email, this.signupUser()!.username)
        .toResult();
    } catch (ex) {
      throw ex;
    } finally {
      // this.pageLoader.hideLoader();
    }
  }
}
