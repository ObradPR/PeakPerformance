import { Routes } from '@angular/router';
import { Constants } from './constants';

export const routes: Routes = [
  {
    path: Constants.NOT_FOUND_ROUTE,
    data: { title: 'Not Found | ' + Constants.TITLE },
    loadComponent: () =>
      import('./pages/errors/not-found/not-found.component').then(
        (m) => m.NotFoundComponent
      ),
  },
  {
    path: Constants.UNAUTHORIZED_ROUTE,
    data: { title: 'Unauthorized | ' + Constants.TITLE },
    loadComponent: () =>
      import('./pages/errors/unauthorized/unauthorized.component').then(
        (m) => m.UnauthorizedComponent
      ),
  },
  {
    path: '**',
    redirectTo: Constants.NOT_FOUND_ROUTE,
    pathMatch: 'full',
  },
];
