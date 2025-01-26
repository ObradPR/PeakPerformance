import { Component, effect, OnDestroy, OnInit, Provider } from '@angular/core';
import { Chart } from 'chart.js/auto';
import { DateTime } from 'luxon';
import { DropdownChangeEvent, DropdownModule } from 'primeng/dropdown';
import { IEnumProvider, IPagingResult, IWeightDto, IWeightSearchOptions } from '../../../_generated/interfaces';
import { WeightController } from '../../../_generated/services';
import { BodyweightService } from '../../../services/bodyweight.service';
import { ModalService } from '../../../services/modal.service';
import { SharedService } from '../../../services/shared.service';
import { Providers } from '../../../_generated/providers';
import { eChartTimespan, eMeasurementUnit } from '../../../_generated/enums';
import { FormsModule } from '@angular/forms';

enum eChartTarget {
  Bodyweight = 1,
  BodyFatPercentage = 2,
}
type TChartTarget = 'weight' | 'bodyFatPercentage';

@Component({
  selector: 'app-bodyweight',
  standalone: true,
  imports: [DropdownModule, FormsModule],
  templateUrl: './bodyweight.component.html',
  styleUrl: './bodyweight.component.scss'
})
export class BodyweightComponent implements OnInit, OnDestroy {
  private chart!: Chart;
  bodyweights: IPagingResult<IWeightDto>;

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

  onTimespanChange = () => this.getBodyweights();
  onTargetChange(event: DropdownChangeEvent) {
    if (event.value === eChartTarget.Bodyweight)
      this.selectedTarget = 'weight';
    else if (event.value === eChartTarget.BodyFatPercentage)
      this.selectedTarget = 'bodyFatPercentage';

    this.getBodyweights();
  }

  private getBodyweights() {
    this.destroyChart();

    const options = {} as IWeightSearchOptions;
    options.chartTimespanId = this.selectedTimespan;

    this.weightController.Search(options).toPromise()
      .then(_ => {
        if (_ !== null) {
          this.bodyweights = _;
          this.chartInit(this.selectedTarget);
          this.infoInit();
        }
      })
      .catch(ex => { throw ex; });
  }

  private getStartDate() {
    const earliestTimestamp = new Date(
      Math.min(...this.bodyweights.data.map(_ => new Date(_.logDate!).getTime()))
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

      const log = this.bodyweights.data.find(_ => {
        const logDate = new Date(_.logDate as Date);
        const localDate = new Date(logDate.getTime() - logDate.getTimezoneOffset() * 60000);
        return DateTime.fromJSDate(localDate).toFormat('MMM dd yyyy') === date;
      });

      return log ? log[target]! : null;
    });

    const values = this.bodyweights.data
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
            min: Math.round(Math.min(...values) - 10),
            max: Math.round(Math.max(...values) + 10),
          },
        },
      },
    });
  }

  private infoInit() {
    this.currentBodyweight = this.bodyweights.data
      .filter(_ => _.weight !== undefined && _.weight !== null)
      .reduce((latest, current) => {
        const latestDate = new Date(latest.logDate!).getTime();
        const currentDate = new Date(current.logDate!).getTime();
        return currentDate > latestDate ? current : latest;
      }, this.bodyweights.data[0]).weight!;

    this.currentBodyFat = this.bodyweights.data
      .filter(_ => _.bodyFatPercentage !== undefined && _.bodyFatPercentage !== null)
      .reduce((latest, current) => {
        const latestDate = new Date(latest.logDate!).getTime();
        const currentDate = new Date(current.logDate!).getTime();
        return currentDate > latestDate ? current : latest;
      }, this.bodyweights.data[0]).bodyFatPercentage!;
  }

  private destroyChart() {
    if (this.chart)
      this.chart.destroy();
  }

  ngOnDestroy(): void {
    this.destroyChart();
  }
}
