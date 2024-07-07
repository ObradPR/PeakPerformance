// import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
// import { inject } from '@angular/core';
// import { Router } from '@angular/router';
// import { ToastService } from '../services/toast.service';
// import { catchError } from 'rxjs';

// export const errorInterceptor: HttpInterceptorFn = (req, next) => {
//   const toast = inject(ToastService);
//   const router = inject(Router);

//   return next(req).pipe(
//     catchError((error: HttpErrorResponse) => {
//       if (error) {
//         switch (error.status) {
//           case 400:
//             if (error.error.errors) {
//               const modelStateErrors = [];
//               for (const key in error.error.errors)
//                 if (error.error.errors[key])
//                   modelStateErrors.push(error.error.errors[key]);
//               throw modelStateErrors.flat();
//             } else toast.showError(error.status.toString(), error.error);
//             break;
//           case 401:
//             router.navigateByUrl('/unauthorized');
//             break;
//           case 404:
//             router.navigateByUrl('/not-found');
//             break;
//           case 422:
//             toast.showError('Validation error', error.message);
//             break;
//           default:
//             toast.showGeneralError();
//             console.error(error);
//             break;
//         }
//       }
//       throw error;
//     })
//   );
// };
