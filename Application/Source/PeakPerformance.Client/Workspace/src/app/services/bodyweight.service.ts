import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BodyweightService {

  // Chart - Bodyweight
  private bodyweights = signal<boolean>(false);
  readonly bodyweightsSignal = this.bodyweights.asReadonly();

  triggerBodyweights() {
    this.bodyweights.set(!this.bodyweights());
  }
}
