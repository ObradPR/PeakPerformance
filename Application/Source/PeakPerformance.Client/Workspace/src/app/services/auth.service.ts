import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private currentUserSource = new BehaviorSubject<any | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private router: Router) {}

  signin(credentials: any) {}

  signup(credentials: any) {}

  signout() {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  setCurrentUser(user: any) {}

  getDecodedToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }

  getToken() {
    return localStorage.getItem('token');
  }
}
