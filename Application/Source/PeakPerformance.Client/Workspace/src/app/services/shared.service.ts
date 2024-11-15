import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  private fromSignup = signal<boolean>(false);

  readonly fromSignupSignal = this.fromSignup.asReadonly();

  setFromSignupSignal(value: boolean) {
    this.fromSignup.set(value);
  }
}
