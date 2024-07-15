import {
  ApplicationConfig,
  Provider,
  provideZoneChangeDetection,
} from '@angular/core';
import { provideRouter } from '@angular/router';

import './extensions/string-extension';
import './extensions/observable-extension';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import {
  provideHttpClient,
  withFetch,
  withInterceptors,
} from '@angular/common/http';
import { jwtInterceptor } from './interceptors/jwt.interceptor';
import { SettingsService } from './services/settings.service';
import { AuthController } from './_generated/services';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideClientHydration(),
    provideAnimations(),
    provideHttpClient(
      withFetch(),
      withInterceptors([jwtInterceptor /*errorInterceptor*/])
    ),
    // MessageService
    servicesProvider(),
    controllersProvider(),
  ],
};

function controllersProvider(): Provider[] {
  return [AuthController];
}

function servicesProvider(): Provider[] {
  return [SettingsService /*MessageService*/];
}
