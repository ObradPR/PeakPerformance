export class Constants {
  // Routes
  static readonly ROUTE_NOT_FOUND = 'not-found';
  static readonly ROUTE_UNAUTHORIZED = 'unauthorized';
  static readonly ROUTE_AUTH = 'auth';
  static readonly ROUTE_SIGN_IN = 'sign-in';
  static readonly ROUTE_SIGN_UP = 'sign-up';

  // Route Titles
  static readonly TITLE = 'PeakPerformance';

  // RegEx

  static readonly REGEX_PASSWORD =
    /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$/;
  static readonly REGEX_PHONE_NUMBER = /^\d{3}-\d{3}-\d{4}$/;

  // Animations
  static readonly FORM_ANIMATION_PERIOD = 150;
}
