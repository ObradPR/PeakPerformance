import { Routes } from '@angular/router';
import { RouteConstants } from './constants';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  ///
  /// AUTH
  ///
  {
    path: RouteConstants.ROUTE_AUTH,
    canActivate: [authGuard],
    children: [
      {
        path: '',
        redirectTo: RouteConstants.ROUTE_SIGN_IN,
        pathMatch: 'full'
      },
      {
        path: ':type',
        title: RouteConstants.TITLE_AUTH,
        loadComponent: () =>
          import('./pages/auth/auth.component').then(_ => _.AuthComponent),
      }
    ],
  },
  ///
  /// HUB
  ///
  {
    path: RouteConstants.ROUTE_HUB_DASHBOARD,
    title: RouteConstants.TITLE_HUB_DASHBOARD,
    loadComponent: () =>
      import('./pages/hub/hub.component').then(_ => _.HUBComponent),
    canActivate: [authGuard],
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./pages/hub/dashboard/dashboard.component').then(_ => _.DashboardComponent)
      },
      {
        path: RouteConstants.ROUTE_HUB_BODYWEIGHT,
        title: RouteConstants.TITLE_HUB_BODYWEIGHT,
        loadComponent: () =>
          import('./pages/hub/bodyweight/bodyweight.component').then(_ => _.BodyweightComponent)
      }
    ]
  },
  ///
  /// Error Pages
  ///
  {
    path: RouteConstants.ROUTE_NOT_FOUND,
    title: RouteConstants.TITLE_NOT_FOUND,
    loadComponent: () =>
      import('./pages/errors/not-found/not-found.component').then(_ => _.NotFoundComponent),
  },
  {
    path: RouteConstants.ROUTE_UNAUTHORIZED,
    title: RouteConstants.TITLE_UNAUTHORIZED,
    loadComponent: () =>
      import('./pages/errors/unauthorized/unauthorized.component').then(_ => _.UnauthorizedComponent),
  },
  {
    path: '**',
    redirectTo: RouteConstants.ROUTE_NOT_FOUND,
    pathMatch: 'full',
  },
];
