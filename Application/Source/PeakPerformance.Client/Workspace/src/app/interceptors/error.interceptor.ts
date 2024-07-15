import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { ToastService } from '../services/toast.service';
import { catchError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const toast = inject(ToastService);
  const router = inject(Router);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error) {
        switch (error.status) {
          case 400:
            toast.showError('Bad request', error.error.Message);
            break;
          case 401:
            toast.showError('Unauthorized', error.error.Message);
            router.navigateByUrl('/unauthorized');
            break;
          case 403:
            toast.showError('Forbidden', error.error.Message);
            router.navigateByUrl('/');
            break;
          case 404:
            toast.showError('Not found', error.error.Message);
            router.navigateByUrl('/not-found');
            break;
          case 422:
            toast.showError('Validation error', error.error.Message);
            break;
          default:
            toast.showGeneralError();
            console.error(error);
            break;
        }
      }
      throw error;
    })
  );
};
