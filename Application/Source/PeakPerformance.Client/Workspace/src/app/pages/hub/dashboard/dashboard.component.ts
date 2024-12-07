import { Component, OnInit } from '@angular/core';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { InputTextModule } from 'primeng/inputtext';
import { ChartBodyweightsComponent } from '../../../components/charts/chart-bodyweights/chart-bodyweights.component';
import { IPagingResult, IWeightDto, IWeightSearchOptions } from '../../../_generated/interfaces';
import { WeightController } from '../../../_generated/services';
import { DateTime } from 'luxon';
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    IconFieldModule,
    InputIconModule,
    InputTextModule,
    ChartBodyweightsComponent
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit {
  bodyweights: IPagingResult<IWeightDto>;

  constructor(private weightController: WeightController) { }

  ngOnInit(): void {
    this.getBodyweights();
  }

  private getBodyweights() {
    const nextDay = DateTime.now().plus({ days: 1 }).startOf('day');
    const sevenDaysBefore = nextDay.minus({ days: 7 }).startOf('day');

    const options = {} as IWeightSearchOptions;
    options.fromDate = sevenDaysBefore.toJSDate();
    options.toDate = nextDay.toJSDate();

    this.weightController.Search(options).toPromise()
      .then(_ => {
        if (_ !== null)
          this.bodyweights = _;
      })
      .catch(ex => { throw ex; });
  }
}
