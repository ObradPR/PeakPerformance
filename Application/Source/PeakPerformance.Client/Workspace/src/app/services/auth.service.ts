import { Injectable, signal } from '@angular/core';
import { Router } from '@angular/router';
import { DateTime } from 'luxon';
import { map } from 'rxjs';
import {
  IAuthorizationDto,
  IChangePasswordDto,
  ISigninDto,
  ISignupDto,
  IUserDto,
  IValidateUserCodeDto,
  IValidateUserDto
} from '../_generated/interfaces';
import { AuthController, UserController } from '../_generated/services';
import { Constants, RouteConstants } from '../constants';
import { SharedService } from './shared.service';
import { StorageService } from './storage.service';
import { LoaderService } from './loader.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  currentUserSource = signal<IUserDto | null>(null);

  constructor(
    private router: Router,
    private authController: AuthController,
    private storageService: StorageService,
    private sharedService: SharedService,
    private loaderService: LoaderService,
    private userController: UserController
  ) { }

  signin(user: ISigninDto) {
    return this.authController.Signin(user);
  }

  signup(user: ISignupDto) {
    return this.authController.Signup(user);
  }

  signout() {
    this.authController.Signout().toPromise()
      .catch(ex => { throw ex; })
      .finally(() => {
        this.storageService.remove(Constants.AUTH_TOKEN);
        this.currentUserSource.set(null);
        this.router.navigateByUrl(RouteConstants.ROUTE_HOME);
      });
  }

  loadCurrentUser() {
    const token = this.getToken();
    if (!token) return;

    this.loaderService.showPageLoader();
    this.userController.GetCurrent().toPromise()
      .then(_ => this.currentUserSource.set(_))
      .catch(ex => { throw ex; })
      .finally(() => this.loaderService.hidePageLoader());
  }

  setUser(data: IAuthorizationDto) {
    const token = this.getToken();

    this.setToken(data.token);

    if (!token) {
      this.router.navigateByUrl(RouteConstants.ROUTE_HUB_DASHBOARD);
      this.loadCurrentUser();
    }
  }

  getDecodedToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }

  setToken(token: string) {
    this.storageService.set(Constants.AUTH_TOKEN, token);
  }

  getToken(): string | null {
    const token = this.storageService.get(Constants.AUTH_TOKEN);
    if (!token)
      return null;

    const decodedToken = this.getDecodedToken(token);
    if (!decodedToken.exp)
      return null;

    const currentTimestamp = DateTime.now().toSeconds();
    if (currentTimestamp >= decodedToken.exp)
      return null;

    return token;
  }

  validateEmail(validateUser: IValidateUserDto) {
    return this.authController.ValidateEmail(validateUser);
  }

  validateUser(validateUser: IValidateUserDto) {
    return this.authController.ValidateUser(validateUser);
  }

  validateCode(validateUserCode: IValidateUserCodeDto) {
    return this.authController.ValidateCode(validateUserCode);
  }

  changePassword(user: IChangePasswordDto) {
    return this.authController.ChangePassword(user);
  }
}
