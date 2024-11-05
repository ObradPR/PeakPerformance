import {
  ApplicationConfig,
  Provider,
  provideZoneChangeDetection,
} from '@angular/core';
import { provideRouter } from '@angular/router';

import {
  provideHttpClient,
  withFetch,
  withInterceptors,
} from '@angular/common/http';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { MessageService } from 'primeng/api';
import { AuthController, UserController } from './_generated/services';
import { routes } from './app.routes';
import './extensions/observable-extension';
import './extensions/string-extension';
import { errorInterceptor } from './interceptors/error.interceptor';
import { jwtInterceptor } from './interceptors/jwt.interceptor';
import { SettingsService } from './services/settings.service';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideClientHydration(),
    provideAnimations(),
    provideHttpClient(
      withFetch(),
      withInterceptors([jwtInterceptor, errorInterceptor])
    ),
    servicesProvider(),
    controllersProvider(),
  ],
};

function controllersProvider(): Provider[] {
  return [AuthController, UserController];
}

function servicesProvider(): Provider[] {
  return [SettingsService, MessageService];
}
