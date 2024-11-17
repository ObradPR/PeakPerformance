import { CommonModule } from '@angular/common';
import { AfterViewInit, Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarouselModule, OwlOptions } from 'ngx-owl-carousel-o';
import { take } from 'rxjs';
import { ISignupDto, IValidateUserDto } from '../../_generated/interfaces';
import { formAnimation } from '../../animations/form.animation';
import { Constants, RouteConstants } from '../../constants';
import { createRoutePath } from '../../extensions/string.extension';
import { LoaderService } from '../../services/loader.service';
import { CodeVerificationComponent } from './code-verification/code-verification.component';
import { PasswordRecoveryComponent } from './password-recovery/password-recovery.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';

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
    CommonModule
  ],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss',
  animations: [formAnimation],
})
export class AuthComponent implements OnInit {
  isSigninFormSignal = signal(false);
  isSignupFormSignal = signal(false);
  isCodeVerifySignal = signal(false);
  isPasswordRecoverySignal = signal(false);
  isChangePasswordSignal = signal(false);
  formType?: TUrlSegment;
  signupUser: ISignupDto | undefined = undefined;
  passwordRecoveryUser: IValidateUserDto | undefined = undefined;
  showForms = false;

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

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    public loaderService: LoaderService,
  ) { }

  ngOnInit(): void {
    this.loaderService.showPageLoader();
    this.takeUrlParam();
    this.showForms = true;
  }

  toggleForms(type: TUrlSegment, isSignin: boolean) {
    if (type === RouteConstants.ROUTE_SIGN_UP) {
      this.router.navigateByUrl(
        createRoutePath(RouteConstants.ROUTE_AUTH, RouteConstants.ROUTE_SIGN_UP)
      );
    } else if (type === RouteConstants.ROUTE_SIGN_IN) {
      this.router.navigateByUrl(
        createRoutePath(RouteConstants.ROUTE_AUTH, RouteConstants.ROUTE_SIGN_IN)
      );
    }

    if (isSignin) {
      this.isSignupFormSignal.set(false);

      setTimeout(() => {
        this.isSigninFormSignal.set(true);
      }, 6 * Constants.FORM_ANIMATION_PERIOD + 100);
    } else {
      this.isSigninFormSignal.set(false);
      setTimeout(() => {
        this.isSignupFormSignal.set(true);
      }, 3 * Constants.FORM_ANIMATION_PERIOD + 100);
    }
  }

  showCodeVerify(user: ISignupDto | IValidateUserDto) {
    if (this.isSignupDto(user)) {
      this.isSignupFormSignal.set(false);

      setTimeout(() => {
        this.signupUser = user;
        this.isCodeVerifySignal.set(true);
      }, 6 * Constants.FORM_ANIMATION_PERIOD + 100);
    } else if (this.isValidateUserDto(user)) {
      this.isPasswordRecoverySignal.set(false);

      setTimeout(() => {
        this.passwordRecoveryUser = user;
        this.isCodeVerifySignal.set(true);
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
      this.isCodeVerifySignal.set(false);
      this.isChangePasswordSignal.set(true);

      setTimeout(() => {
        this.passwordRecoveryUser = user;
        this.isPasswordRecoverySignal.set(true);
      }, 2 * Constants.FORM_ANIMATION_PERIOD + 100);
    } else {
      this.isSigninFormSignal.set(false);
      this.isChangePasswordSignal.set(false);

      setTimeout(() => {
        this.isPasswordRecoverySignal.set(true);
      }, 3 * Constants.FORM_ANIMATION_PERIOD + 100);
    }
  }

  backToSignin() {
    this.isPasswordRecoverySignal.set(false);

    setTimeout(() => {
      this.isSigninFormSignal.set(true);
    }, 3 * Constants.FORM_ANIMATION_PERIOD + 100);
  }

  private takeUrlParam() {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      this.formType = params.get('type');

      if (
        this.formType !== RouteConstants.ROUTE_SIGN_IN &&
        this.formType !== RouteConstants.ROUTE_SIGN_UP
      ) {
        this.toggleForms(RouteConstants.ROUTE_SIGN_IN, true);
      } else {
        this.toggleForms(
          this.formType,
          this.formType === RouteConstants.ROUTE_SIGN_IN ? true : false
        );
      }
    });
  }
}
