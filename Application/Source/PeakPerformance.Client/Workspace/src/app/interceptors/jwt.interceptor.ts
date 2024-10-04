import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { take } from 'rxjs';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const user = authService.currentUserSource();

  if (user) {
    req = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${user.token}`),
    });
  }

  return next(req);
};
