import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { RouteConstants } from '../constants';
import { createRoutePath } from '../extensions/string.extension';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const url = state.url;
  const token = authService.getToken();

  if (typeof window !== 'undefined') {
    if (!token && !url.includes(RouteConstants.ROUTE_AUTH)) {
      router.navigateByUrl(
        createRoutePath(RouteConstants.ROUTE_AUTH, RouteConstants.ROUTE_SIGN_IN)
      );
      return false;
    }
    else if (token && url.includes(RouteConstants.ROUTE_AUTH)) {
      router.navigateByUrl(RouteConstants.ROUTE_HUB_DASHBOARD);
      return false;
    }

    return true;
  }

  return false;
};
