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
import { SectionLoaderComponent } from '../../../components/section-loader/section-loader.component';
import { LoaderService } from '../../../services/loader.service';

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
    SectionLoaderComponent
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
    private toastService: ToastService,
    public loaderService: LoaderService
  ) { }

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
    if (this.passwordRecoveryForm.invalid) {
      this.toastService.showFormError();
      return;
    }

    this.loaderService.showSectionLoader();

    const validateUser: IValidateUserDto = {
      username: this.passwordRecoveryForm.value.username,
      email: this.passwordRecoveryForm.value.email,
    };

    this.authService.validateUser(validateUser).toPromise()
      .then(_ => this.showCodeVerifyEvent.emit(validateUser))
      .catch(ex => { throw ex; })
      .finally(() => this.loaderService.hideSectionLoader());
  }

  onBackToSignin() {
    this.backToSigninEvent.emit();
  }

  async onPasswordChange() {
    if (this.passwordChangeForm.invalid) {
      this.toastService.showFormError();
      return;
    }

    this.loaderService.showSectionLoader();

    const user: IChangePasswordDto = {
      username: this.passwordRecoveryUser()?.username!,
      email: this.passwordRecoveryUser()?.email!,
      password: this.passwordChangeForm.value.password,
      confirmPassword: this.passwordChangeForm.value.confirmPassword,
    };


    this.authService.changePassword(user).toPromise()
      .then(_ => {
        this.toastService.showGeneralSuccess();
        this.onBackToSignin();
      })
      .catch(ex => { throw ex; })
      .finally(() => this.loaderService.hideSectionLoader());
  }
}
