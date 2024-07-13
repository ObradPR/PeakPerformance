import { Component, OnInit, output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Constants } from '../../../constants';

@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss',
})
export class SignInComponent implements OnInit {
  showSignUpFormEvent = output<string>();
  signInForm: FormGroup = this.fb.group({});

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  private initializeForm() {
    this.signInForm = this.fb.group({
      username: ['', Validators.required],
    });
  }

  onShowSignUp() {
    this.showSignUpFormEvent.emit(Constants.ROUTE_SIGN_UP);
  }
}
