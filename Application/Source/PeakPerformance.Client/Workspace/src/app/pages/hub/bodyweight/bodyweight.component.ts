import { Component, effect, OnDestroy, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Chart } from 'chart.js/auto';
import { DateTime } from 'luxon';
import { DropdownChangeEvent, DropdownModule } from 'primeng/dropdown';
import { eChartTimespan } from '../../../_generated/enums';
import { IEnumProvider, IPagingResult, ISortingOptions, IWeightDto, IWeightSearchOptions } from '../../../_generated/interfaces';
import { Providers } from '../../../_generated/providers';
import { WeightController } from '../../../_generated/services';
import { BodyweightService } from '../../../services/bodyweight.service';
import { ModalService } from '../../../services/modal.service';
import { SharedService } from '../../../services/shared.service';
import { CommonModule } from '@angular/common';
import { PaginatorModule } from 'primeng/paginator';
import { UtcToLocalPipe } from '../../../pipes/utc-to-local.pipe';

enum eChartTarget {
  Bodyweight = 1,
  BodyFatPercentage = 2,
}
type TChartTarget = 'weight' | 'bodyFatPercentage';

@Component({
  selector: 'app-bodyweight',
  standalone: true,
  imports: [
    DropdownModule,
    FormsModule,
    CommonModule,
    PaginatorModule,
    UtcToLocalPipe
  ],
  templateUrl: './bodyweight.component.html',
  styleUrl: './bodyweight.component.scss'
})
export class BodyweightComponent implements OnInit, OnDestroy {
  private chart!: Chart;
  bodyweightsChart: IPagingResult<IWeightDto>;
  bodyweights?: IPagingResult<IWeightDto>;

  chartTimespans: IEnumProvider[] = this.referenceService.getChartTimespans();
  selectedTimespan: number = eChartTimespan.Last3Months;
  chartTargets: IEnumProvider[] = [
    {
      id: eChartTarget.Bodyweight,
      description: 'Bodyweight',
      name: ''
    },
    {
      id: eChartTarget.BodyFatPercentage,
      description: 'Body Fat',
      name: ''
    }
  ]
  selectedTarget: TChartTarget = 'weight';

  currentBodyweight: number;
  currentBodyFat: number;
  currentGoal: number;

  selectedTab: number = 0;
  tabs = [
    {
      label: 'Bodyweights',
      icon: 'M5,2H19A2,2 0 0,1 21,4V20A2,2 0 0,1 19,22H5A2,2 0 0,1 3,20V4A2,2 0 0,1 5,2M12,4A4,4 0 0,0 8,8H11.26L10.85,5.23L12.9,8H16A4,4 0 0,0 12,4M5,10V20H19V10H5Z',
      iconTitle: 'scale-bathroom'
    },
    {
      label: 'Goals',
      icon: 'M16,11.78L20.24,4.45L21.97,5.45L16.74,14.5L10.23,10.75L5.46,19H22V21H2V3H4V17.54L9.5,8L16,11.78Z',
      iconTitle: 'chart-line'
    }
  ];

  bodyweightsFirst = 0;
  rows = 7;

  constructor(
    private sharedService: SharedService,
    private weightController: WeightController,
    public modalService: ModalService,
    private bodyweightService: BodyweightService,
    private referenceService: Providers
  ) {
    effect(() => {
      this.bodyweightService.bodyweightChartSignal();
      this.getBodyweights();
    }, { allowSignalWrites: true })

    this.sharedService.pushBreadcrumbItem({ label: 'Bodyweight', routerLink: '/hub/bodyweight' });
  }

  ngOnInit(): void { }

  onSelectTab(idx: number): void {
    this.selectedTab = idx;
  }

  onTimespanChange = () => this.getBodyweightsChart();
  onTargetChange(event: DropdownChangeEvent) {
    if (event.value === eChartTarget.Bodyweight)
      this.selectedTarget = 'weight';
    else if (event.value === eChartTarget.BodyFatPercentage)
      this.selectedTarget = 'bodyFatPercentage';

    this.getBodyweightsChart();
  }
  onPageChange(event: any) {
    console.log(event);
    this.bodyweightsFirst = event.first;
    this.rows = event.rows;
    this.getPaginatedBodyweights(this.bodyweightsFirst, this.rows);
  }


  private getBodyweights() {
    this.getBodyweightsChart();
    this.getPaginatedBodyweights(this.bodyweightsFirst, this.rows);
  }

  private getPaginatedBodyweights(skip: number, take: number) {
    const options = {} as IWeightSearchOptions;
    options.take = take;
    options.skip = skip;
    options.sortingOptions = [{ field: 'LogDate', dir: 'desc' }] as ISortingOptions[];

    this.weightController.Search(options).toPromise()
      .then(_ => {
        if (_ !== null) {
          this.bodyweights = _;
        }
      })
      .catch(ex => { throw ex; });
  }

  private getBodyweightsChart() {
    this.destroyChart();

    const options = {} as IWeightSearchOptions;
    options.chartTimespanId = this.selectedTimespan;

    this.weightController.Search(options).toPromise()
      .then(_ => {
        if (_ !== null) {
          this.bodyweightsChart = _;
          this.chartInit(this.selectedTarget);
          this.infoInit();
        }
      })
      .catch(ex => { throw ex; });
  }

  private getStartDate() {
    const earliestTimestamp = new Date(
      Math.min(...this.bodyweightsChart.data.map(_ => new Date(_.logDate!).getTime()))
    );

    const earliestDate = new Date(earliestTimestamp.getTime() - earliestTimestamp.getTimezoneOffset() * 60000);
    return DateTime.fromJSDate(earliestDate);
  }

  private chartInit(target: TChartTarget) {
    const today = DateTime.local();
    const startDate = this.selectedTimespan !== eChartTimespan.AllTime
      ? today.minus({ months: this.selectedTimespan })
      : this.getStartDate();

    const allDates: string[] = [];
    const totalDays = today.diff(startDate, 'days').days;
    for (let i = 0; i <= totalDays; i++) {
      const date = startDate.plus({ days: i });
      allDates.push(date.toFormat('MMM dd yyyy'));
    }

    const dataForChart: (number | null)[] = allDates.map(date => {
      // const formattedDate = DateTime.fromFormat(date, 'MMM ddd'); // this can be useful for year maybe (for all time showcase)

      const log = this.bodyweightsChart.data.find(_ => {
        const logDate = new Date(_.logDate as Date);
        const localDate = new Date(logDate.getTime() - logDate.getTimezoneOffset() * 60000);
        return DateTime.fromJSDate(localDate).toFormat('MMM dd yyyy') === date;
      });

      return log ? log[target]! : null;
    });

    const values = this.bodyweightsChart.data
      .map(_ => _[target]!)
      .filter(_ => _ !== undefined && _ !== null);

    this.chart = new Chart('bodyweights-line-chart', {
      type: 'line',
      data: {
        labels: allDates,
        datasets: [
          {
            label: 'Bodyweight',
            data: dataForChart,
            backgroundColor: 'rgba(0, 123, 255, 1)',
            borderColor: 'rgba(0, 123, 255, 1)',
            borderWidth: 2,
            tension: 0.3,
            spanGaps: true
          },
        ],
      },
      options: {
        responsive: true,
        scales: {
          x: {
            ticks: {
              maxTicksLimit: 8
            }
          },
          y: {
            min: this.sharedService.roundToNearestTen(Math.max(0, Math.round(Math.min(...values) - 30))),
            max: this.sharedService.roundToNearestTen(Math.round(Math.max(...values) + 30)),
          },
        },
      },
    });
  }

  private infoInit() {
    this.currentBodyweight = this.bodyweightsChart.data
      .filter(_ => _.weight !== undefined && _.weight !== null)
      .reduce((latest, current) => {
        const latestDate = new Date(latest.logDate!).getTime();
        const currentDate = new Date(current.logDate!).getTime();
        return currentDate > latestDate ? current : latest;
      }, this.bodyweightsChart.data[0]).weight!;

    this.currentBodyFat = this.bodyweightsChart.data
      .filter(_ => _.bodyFatPercentage !== undefined && _.bodyFatPercentage !== null)
      .reduce((latest, current) => {
        const latestDate = new Date(latest.logDate!).getTime();
        const currentDate = new Date(current.logDate!).getTime();
        return currentDate > latestDate ? current : latest;
      }, this.bodyweightsChart.data[0]).bodyFatPercentage!;
  }

  private destroyChart() {
    if (this.chart)
      this.chart.destroy();
  }

  ngOnDestroy(): void {
    this.destroyChart();
  }
}
