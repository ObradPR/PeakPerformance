import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { RouteConstants } from '../constants';
import { createRoutePath } from '../extensions/string.extension';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const token = authService.getToken();

  if (token) {
    return true;
  } else {
    router.navigateByUrl(
      createRoutePath(RouteConstants.ROUTE_AUTH, RouteConstants.ROUTE_SIGN_IN)
    );
    return false;
  }
};
