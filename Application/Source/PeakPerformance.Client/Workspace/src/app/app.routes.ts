import { Routes } from '@angular/router';
import { Constants } from './constants';

export const routes: Routes = [
  {
    path: Constants.ROUTE_AUTH,
    loadComponent: () =>
      import('./pages/auth/auth.component').then((m) => m.AuthComponent),
    children: [
      {
        path: ':type',
        title: 'Auth | ' + Constants.TITLE,
        loadComponent: () =>
          import('./pages/auth/auth.component').then((m) => m.AuthComponent),
      },
    ],
  },
  {
    path: Constants.ROUTE_NOT_FOUND,
    title: 'Not Found | ' + Constants.TITLE,
    loadComponent: () =>
      import('./pages/errors/not-found/not-found.component').then(
        (m) => m.NotFoundComponent
      ),
  },
  {
    path: Constants.ROUTE_UNAUTHORIZED,
    title: 'Unauthorized | ' + Constants.TITLE,
    loadComponent: () =>
      import('./pages/errors/unauthorized/unauthorized.component').then(
        (m) => m.UnauthorizedComponent
      ),
  },
  {
    path: '**',
    redirectTo: Constants.ROUTE_NOT_FOUND,
    pathMatch: 'full',
  },
];
