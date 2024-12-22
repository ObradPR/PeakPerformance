import { Component, OnInit } from '@angular/core';
import { DateTime } from 'luxon';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { InputTextModule } from 'primeng/inputtext';
import { IPagingResult, IWeightDto, IWeightSearchOptions } from '../../../_generated/interfaces';
import { WeightController } from '../../../_generated/services';
import { AreaChartComponent } from "../../../components/charts/area-chart/area-chart.component";
import { IAreaChartOptions } from '../../../components/charts/interfaces/area-chart-options.interface';
import { ModalService } from '../../../services/modal.service';
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    IconFieldModule,
    InputIconModule,
    InputTextModule,
    AreaChartComponent
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit {
  bodyweights: IPagingResult<IWeightDto>;
  bodyweightsChartsOptions: IAreaChartOptions = {
    xField: 'logDate',
    yField: 'weight',
    yFieldDefaultValue: 100,
    height: 200,
    showToolbar: false,
    xType: 'datetime'
  }

  constructor(private weightController: WeightController, public modalService: ModalService) { }

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
