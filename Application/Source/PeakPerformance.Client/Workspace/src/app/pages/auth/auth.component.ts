import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarouselModule, OwlOptions } from 'ngx-owl-carousel-o';
import { take } from 'rxjs';
import { formAnimation } from '../../animations/form-animation';
import { Constants } from '../../constants';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';

type TLayoutType = 'sign-in' | 'sign-up';
type TUrlSegment = string | null | TLayoutType | undefined;

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [SignInComponent, SignUpComponent, CarouselModule],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss',
  animations: [formAnimation],
})
export class AuthComponent implements OnInit {
  formType?: TUrlSegment;
  isSigninForm = signal(true);
  isSignupForm = signal(false);

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
      }, 900);
    } else {
      this.isSigninForm.set(false);
      setTimeout(() => {
        this.isSignupForm.set(true);
      }, 450);
    }
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
