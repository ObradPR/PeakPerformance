import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { RouteConstants } from '../constants';

export const guestGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const token = authService.getToken();

  if (!token) {
    return true;
  } else {
    router.navigateByUrl(RouteConstants.ROUTE_HUB_DASHBOARD);
    return false;
  }
};