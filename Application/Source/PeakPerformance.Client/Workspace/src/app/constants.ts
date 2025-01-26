export class Constants {
  // RegEx
  static REGEX_PASSWORD =
    /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$/;
  static REGEX_PHONE_NUMBER = /^\d{3}-\d{3}-\d{4}$/;

  // Animations
  static FORM_ANIMATION_PERIOD = 150;

  // Local Storage
  static AUTH_TOKEN = 'token';

  // Messages
  static SUCCESS = 'Success';
  static SUCCESS_MESSAGE = 'Successfully done.';
  static FAILED = 'Failed';
  static FAILED_DATA_MESSAGE = 'Check your data!';

  // Errors
  static ERROR_BAD_REQUEST = 'Bad request';
  static ERROR_UNAUTHORIZED = 'Unauthorized';
  static ERROR_FORBIDDEN = 'Forbidden';
  static ERROR_NOT_FOUND = 'Not found';
  static ERROR_VALIDATION = 'Validation error';
  static ERROR_SERVER = 'Server error';
  static ERROR_SERVER_MESSAGE =
    'Something unexpected went wrong. Please contact administrator for more information.';

  // Image
  static IMAGE_MAX_SIZE_MB = 5;
  static IMAGE_MAX_SIZE_BYTE = 5 * 1024 * 1024;

  // Colors
  static WHITE_HEX = '#FFFFFF';
  static TEAL_HEX = '#20C997';
  static DARK_GREY_HEX = '#343A40';

  // Font
  static APP_FONT = 'Roboto, sans-serif';
}

export class RouteConstants {
  static TITLE = 'PeakPerformance';

  // Error Pages
  static ROUTE_NOT_FOUND = 'not-found';
  static TITLE_NOT_FOUND = 'Not Found | ' + this.TITLE;

  static ROUTE_UNAUTHORIZED = 'unauthorized';
  static TITLE_UNAUTHORIZED = 'Unauthorized | ' + this.TITLE;

  // Auth
  static ROUTE_AUTH = 'auth';
  static TITLE_AUTH = 'Auth | ' + this.TITLE;

  static ROUTE_SIGN_IN = 'sign-in';
  static ROUTE_SIGN_UP = 'sign-up';

  // HUB
  static ROUTE_HUB_DASHBOARD = 'hub';
  static TITLE_HUB_DASHBOARD = 'HUB Dashboard | ' + this.TITLE;
  static ROUTE_HUB_BODYWEIGHT = 'bodyweight';
  static TITLE_HUB_BODYWEIGHT = 'HUB Bodyweight | ' + this.TITLE;

  // Website
  static ROUTE_HOME = '/';
  static TITLE_HOME = 'Home | ' + this.TITLE;
}