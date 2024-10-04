import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PageLoaderService {
  loaderSubject = signal<boolean>(false);

  constructor() {}

  showLoader() {
    this.loaderSubject.set(true);
  }

  hideLoader() {
    this.loaderSubject.set(false);
  }
}
