import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarouselModule, OwlOptions } from 'ngx-owl-carousel-o';
import { take } from 'rxjs';
import { formAnimation } from '../../animations/form-animation';
import { Constants } from '../../constants';
import { CodeVerificationComponent } from './code-verification/code-verification.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ISignupDto, IValidateUserDto } from '../../_generated/interfaces';
import { PasswordRecoveryComponent } from './password-recovery/password-recovery.component';

type TLayoutType = 'sign-in' | 'sign-up';
type TUrlSegment = string | null | TLayoutType | undefined;

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [
    SignInComponent,
    SignUpComponent,
    CarouselModule,
    CodeVerificationComponent,
    PasswordRecoveryComponent,
  ],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss',
  animations: [formAnimation],
})
export class AuthComponent implements OnInit {
  formType?: TUrlSegment;
  isSigninForm = signal(true);
  isSignupForm = signal(false);
  isCodeVerify = signal(false);
  isPasswordRecovery = signal(false);
  isChangePassword = signal(false);
  signupUser: ISignupDto | undefined = undefined;
  passwordRecoveryUser: IValidateUserDto | undefined = undefined;

  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: false,
    touchDrag: false,
    pullDrag: false,
    dots: false,
    nav: false,
    items: 1,
    autoplay: true,
    autoplayTimeout: 10000,
    animateOut: 'fadeOut',
    navSpeed: 1000,
  };

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.takeUrlParam();
  }

  toggleForms(type: TUrlSegment, isSignin: boolean) {
    if (type === Constants.ROUTE_SIGN_UP) {
      this.router.navigateByUrl('/auth/' + Constants.ROUTE_SIGN_UP);
    } else if (type === Constants.ROUTE_SIGN_IN) {
      this.router.navigateByUrl('auth/' + Constants.ROUTE_SIGN_IN);
    }

    if (isSignin) {
      this.isSignupForm.set(false);

      setTimeout(() => {
        this.isSigninForm.set(true);
      }, 6 * Constants.FORM_ANIMATION_PERIOD + 100);
    } else {
      this.isSigninForm.set(false);
      setTimeout(() => {
        this.isSignupForm.set(true);
      }, 3 * Constants.FORM_ANIMATION_PERIOD + 100);
    }
  }

  showCodeVerify(user: ISignupDto | IValidateUserDto) {
    if (this.isSignupDto(user)) {
      this.isSignupForm.set(false);

      setTimeout(() => {
        this.signupUser = user;
        this.isCodeVerify.set(true);
      }, 6 * Constants.FORM_ANIMATION_PERIOD + 100);
    } else if (this.isValidateUserDto(user)) {
      this.isPasswordRecovery.set(false);

      setTimeout(() => {
        this.passwordRecoveryUser = user;
        this.isCodeVerify.set(true);
      }, 3 * Constants.FORM_ANIMATION_PERIOD + 100);
    }
  }

  private isSignupDto(obj: any): obj is ISignupDto {
    return 'password' in obj && 'dateOfBirth' in obj && 'middleName' in obj;
  }

  private isValidateUserDto(obj: any): obj is IValidateUserDto {
    return 'username' in obj && 'email' in obj;
  }

  showPasswordRecovery(
    user: IValidateUserDto | undefined,
    changePassword: boolean
  ) {
    if (changePassword) {
      this.isCodeVerify.set(false);
      this.isChangePassword.set(true);

      setTimeout(() => {
        this.passwordRecoveryUser = user;
        this.isPasswordRecovery.set(true);
      }, 2 * Constants.FORM_ANIMATION_PERIOD + 100);
    } else {
      this.isSigninForm.set(false);
      this.isChangePassword.set(false);

      setTimeout(() => {
        this.isPasswordRecovery.set(true);
      }, 3 * Constants.FORM_ANIMATION_PERIOD + 100);
    }
  }

  backToSignin() {
    this.isPasswordRecovery.set(false);

    setTimeout(() => {
      this.isSigninForm.set(true);
    }, 3 * Constants.FORM_ANIMATION_PERIOD + 100);
  }

  private takeUrlParam() {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      this.formType = params.get('type');

      if (
        this.formType !== Constants.ROUTE_SIGN_IN &&
        this.formType !== Constants.ROUTE_SIGN_UP
      ) {
        this.toggleForms(Constants.ROUTE_SIGN_IN, true);
      } else {
        this.toggleForms(
          this.formType,
          this.formType === Constants.ROUTE_SIGN_IN ? true : false
        );
      }
    });
  }
}
