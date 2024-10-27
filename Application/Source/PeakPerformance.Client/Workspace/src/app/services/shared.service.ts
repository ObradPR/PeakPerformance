import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  fromSignupSignal = signal<boolean>(false);
}
