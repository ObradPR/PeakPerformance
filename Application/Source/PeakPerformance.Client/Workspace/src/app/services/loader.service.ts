import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  private pageLoader = signal<boolean>(false);
  private sectionLoader = signal<boolean>(false);

  readonly pageLoaderSignal = this.pageLoader.asReadonly();
  readonly sectionLoaderSignal = this.sectionLoader.asReadonly();

  constructor() { }

  // Page Loader

  showPageLoader() {
    this.pageLoader.set(true);
  }

  hidePageLoader() {
    this.pageLoader.set(false);
  }

  // Section Loader

  showSectionLoader() {
    this.sectionLoader.set(true);
  }

  hideSectionLoader() {
    this.sectionLoader.set(false);
  }
}
