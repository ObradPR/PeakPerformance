import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { ToastService } from '../services/toast.service';
import { catchError } from 'rxjs';
import { Constants, RouteConstants } from '../constants';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const toast = inject(ToastService);
  const router = inject(Router);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error) {
        switch (error.status) {
          case 400:
            toast.showError(Constants.ERROR_BAD_REQUEST, error.error.Message);
            break;
          case 401:
            toast.showError(Constants.ERROR_UNAUTHORIZED, error.error.Message);
            router.navigateByUrl(RouteConstants.ROUTE_UNAUTHORIZED);
            break;
          case 403:
            toast.showError(Constants.ERROR_FORBIDDEN, error.error.Message);
            router.navigateByUrl(RouteConstants.ROUTE_HOME);
            break;
          case 404:
            toast.showError(Constants.ERROR_NOT_FOUND, error.error.Message);
            router.navigateByUrl(RouteConstants.ROUTE_NOT_FOUND);
            break;
          case 422:
            toast.showError(Constants.ERROR_VALIDATION, error.error.Message);
            break;
          case 500:
            toast.showGeneralError();
            console.error(error);
            break;
          default:
            break;
        }
      }
      throw error;
    })
  );
};
