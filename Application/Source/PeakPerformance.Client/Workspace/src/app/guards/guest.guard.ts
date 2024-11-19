import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { RouteConstants } from '../constants';
import { AuthService } from '../services/auth.service';

// SHOUDL DELETE THIS ONE, EVERYTHING SHOUDL BE IN AUTH GUARD
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