import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BodyweightService {

  // Chart - Bodyweight
  private bodyweightChart = signal<boolean>(false);
  readonly bodyweightChartSignal = this.bodyweightChart.asReadonly();

  triggerBodyweightChart() {
    this.bodyweightChart.set(!this.bodyweightChart());
  }
}
