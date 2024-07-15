import { Component, OnInit, output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Constants } from '../../../constants';

import { PasswordModule } from 'primeng/password';

@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, PasswordModule],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss',
})
export class SignInComponent implements OnInit {
  showSignupFormEvent = output<string>();
  signinForm: FormGroup = this.fb.group({});

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  private initializeForm() {
    this.signinForm = this.fb.group({
      username: ['', Validators.required],
    });
  }

  onShowSignup() {
    this.showSignupFormEvent.emit(Constants.ROUTE_SIGN_UP);
  }
}
