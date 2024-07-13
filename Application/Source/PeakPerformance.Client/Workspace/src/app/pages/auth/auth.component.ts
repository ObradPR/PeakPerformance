import {
  Component,
  ElementRef,
  OnInit,
  Renderer2,
  signal,
} from '@angular/core';
import { ActivatedRoute, RedirectCommand, Router } from '@angular/router';
import { CarouselModule, OwlOptions } from 'ngx-owl-carousel-o';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { Constants } from '../../constants';
import { formAnimation } from '../../animations/form-animation';
import { take } from 'rxjs';

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
  isSignInForm = signal(true);
  isSignUpForm = signal(false);

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
    private elementRef: ElementRef,
    private renderer: Renderer2,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.takeUrlParam();
    this.selectLayout(this.formType);
  }

  private selectLayout(type: TUrlSegment) {}

  private activeFormsState() {}

  private nonActiveFormsState() {}
  count = 0;
  animationDelay = 1000;
  toggleForms(type: TUrlSegment, isSignIn: boolean) {
    console.log(type);
    if (type === Constants.ROUTE_SIGN_UP) {
      this.router.navigateByUrl('/auth/' + Constants.ROUTE_SIGN_UP);
    } else if (type === Constants.ROUTE_SIGN_IN) {
      this.router.navigateByUrl('auth/' + Constants.ROUTE_SIGN_IN);
    }

    if (isSignIn) {
      this.isSignUpForm.set(false);

      setTimeout(() => {
        this.isSignInForm.set(true);
      }, 1000);
    } else {
      this.isSignInForm.set(false);
      setTimeout(() => {
        this.isSignUpForm.set(true);
      }, 450);
    }
  }

  private takeUrlParam() {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      this.formType = params.get('type');
      this.toggleForms(
        this.formType,
        this.formType === Constants.ROUTE_SIGN_IN ? true : false
      );
    });
  }
}
