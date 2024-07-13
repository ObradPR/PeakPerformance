import { Component, output } from '@angular/core';
import { Constants } from '../../../constants';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss',
})
export class SignUpComponent {
  showSignInFormEvent = output<string>();

  onShowSignIn() {
    this.showSignInFormEvent.emit(Constants.ROUTE_SIGN_IN);
  }
}
