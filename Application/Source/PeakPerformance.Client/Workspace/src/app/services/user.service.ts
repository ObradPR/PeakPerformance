import { Injectable } from '@angular/core';
import { UserController } from '../_generated/services';
import { IProfileSetupDto } from '../_generated/interfaces';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private userController: UserController) { }

  profileSetup(data: FormData) {
    return this.userController.ProfileSetup(data);
  }
}
