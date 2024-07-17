import { Injectable, signal } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, map } from 'rxjs';
import {
  IAuthorizationDto,
  ISigninDto,
  ISignupDto,
} from '../_generated/interfaces';
import { AuthController } from '../_generated/services';
import { DateTime } from 'luxon';

// Interfaces
interface IUserSource {
  id: string;
  username: string;
  name: string;
  email: string;
  roles: string[];
  token: string;
  tokenExpireDate: Date;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private currentUserSource = new BehaviorSubject<IUserSource | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private router: Router, private authController: AuthController) {}

  signin(user: ISigninDto) {
    return this.authController.Signin(user).pipe(
      map((result) => {
        if (result) this.setCurrentUser(result);
        return result;
      })
    );
  }

  signup(user: ISignupDto) {
    return this.authController.Signup(user).pipe(
      map((result) => {
        if (result) this.setCurrentUser(result);
        return result;
      })
    );
  }

  signout() {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  setCurrentUser(result: IAuthorizationDto) {
    const tokenInfo = this.getDecodedToken(result.token);

    const userSource: IUserSource = {
      id: tokenInfo.ID,
      username: tokenInfo.USERNAME,
      name: tokenInfo.FULLNAME,
      email: tokenInfo.EMAIL,
      roles: [],
      token: result.token,
      tokenExpireDate: DateTime.fromMillis(tokenInfo.exp * 1000).toJSDate(),
    };
    Array.isArray(tokenInfo.roles)
      ? (userSource.roles = tokenInfo.ROLES)
      : userSource.roles.push(tokenInfo.ROLES);

    localStorage.setItem('token', result.token);
    this.currentUserSource.next(userSource);
    this.router.navigateByUrl('/');
  }

  getDecodedToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }

  getToken() {
    return localStorage.getItem('token');
  }

  validateEmail(email: string, username: string) {
    return this.authController.ValidateEmail(email, username);
  }
}
