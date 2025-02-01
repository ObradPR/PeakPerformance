import { Injectable, signal } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  // Account setup

  private fromSignup = signal<boolean>(false);
  readonly fromSignupSignal = this.fromSignup.asReadonly();

  setFromSignupSignal(value: boolean) {
    this.fromSignup.set(value);
  }

  // Breadcrumb

  private breadcrumbItems = signal<MenuItem[]>([]);
  readonly breadCrumbItemsSignal = this.breadcrumbItems.asReadonly();

  pushBreadcrumbItem(item: MenuItem) {
    const currentArr = this.breadcrumbItems();
    const idx = currentArr.indexOf((_: MenuItem) => _.label === item.label);

    if (idx !== -1)
      this.breadcrumbItems.set(currentArr.slice(0, idx + 1));
    else
      this.breadcrumbItems.set([...currentArr, item]);
  }

  // Nunmber

  roundToNearestTen(value: number): number {
    return Math.round(value / 10) * 10;
  }
}