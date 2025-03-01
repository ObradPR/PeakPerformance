import { Component, effect, OnDestroy, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Chart } from 'chart.js/auto';
import { DateTime } from 'luxon';
import { DropdownChangeEvent, DropdownModule } from 'primeng/dropdown';
import { eChartTimespan, eMeasurementUnit } from '../../../_generated/enums';
import { IEnumProvider, IPagingResult, ISortingOptions, IWeightDto, IWeightGoalDto, IWeightGoalSearchOptions, IWeightSearchOptions } from '../../../_generated/interfaces';
import { Providers } from '../../../_generated/providers';
import { WeightController, WeightGoalController } from '../../../_generated/services';
import { BodyweightService } from '../../../services/bodyweight.service';
import { ModalService } from '../../../services/modal.service';
import { SharedService } from '../../../services/shared.service';
import { CommonModule } from '@angular/common';
import { PaginatorModule, PaginatorState } from 'primeng/paginator';
import { UtcToLocalPipe } from '../../../pipes/utc-to-local.pipe';
import { ClickOutsideDirective } from '../../../directives/click-outside.directive';
import { QService } from '../../../services/q.service';
import ChartDataLabels from 'chartjs-plugin-datalabels';
import { MeasurementConverterPipe } from '../../../pipes/measurement-converter.pipe';
import { AuthService } from '../../../services/auth.service';

// LOCALS

enum eChartTarget {
  Bodyweight = 1,
  BodyFatPercentage = 2,
}
enum eBodyweightInfoTab {
  Bodyweights = 0,
  Goals = 1,
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
    UtcToLocalPipe,
    ClickOutsideDirective,
    MeasurementConverterPipe
  ],
  templateUrl: './bodyweight.component.html',
  styleUrl: './bodyweight.component.scss'
})
export class BodyweightComponent implements OnInit, OnDestroy {
  private chart!: Chart;
  bodyweightsChart: IPagingResult<IWeightDto>;
  bodyweights?: IPagingResult<IWeightDto>;
  bodyweightGoalsChart: IPagingResult<IWeightGoalDto>;
  bodyweightGoals?: IPagingResult<IWeightGoalDto>;

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

  currentBodyFat: number;
  currentBodyweight: {
    weight: number;
    weightUnitId: eMeasurementUnit;
  } = { weight: 0, weightUnitId: 0 };
  currentGoal: {
    weight: number;
    weightUnitId: eMeasurementUnit;
  } = { weight: 0, weightUnitId: 0 };

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
  bodyweightGoalsFirst = 0;
  rows = 7;

  selectedBodyweightMenu: number | null;
  selectedBodyweightGoalMenu: number | null;


  constructor(
    private sharedService: SharedService,
    private weightController: WeightController,
    private weightGoalController: WeightGoalController,
    public modalService: ModalService,
    private bodyweightService: BodyweightService,
    private referenceService: Providers,
    private $q: QService
  ) {
    effect(() => {
      this.bodyweightService.bodyweightsSignal();
      this.getBodyweights();
      this.getBodyweightGoals();
    }, { allowSignalWrites: true })

    this.sharedService.pushBreadcrumbItem({ label: 'Bodyweight', routerLink: '/hub/bodyweight' });
  }

  ngOnInit(): void { }

  // events

  onSelectTab = (idx: number) => this.selectedTab = idx;
  onTimespanChange = () => this.getBodyweightsAndGoalsChart();
  onTargetChange(event: DropdownChangeEvent) {
    if (event.value === eChartTarget.Bodyweight)
      this.selectedTarget = 'weight';
    else if (event.value === eChartTarget.BodyFatPercentage)
      this.selectedTarget = 'bodyFatPercentage';

    this.getBodyweightsAndGoalsChart();
  }
  onPageChange(event: PaginatorState) {
    if (this.selectedTab === eBodyweightInfoTab.Bodyweights) {
      this.bodyweightsFirst = event.first ?? this.bodyweightsFirst;
      this.rows = event.rows ?? this.rows;
      this.getPaginatedBodyweights(this.bodyweightsFirst, this.rows);
    }
    else if (this.selectedTab === eBodyweightInfoTab.Goals) {
      this.bodyweightGoalsFirst = event.first ?? this.bodyweightGoalsFirst;
      this.rows = event.rows ?? this.rows;
      this.getPaginatedBodyweightGoals(this.bodyweightGoalsFirst, this.rows);
    }
  }
  onOpenEditMenu(idx: number) {
    if (this.selectedTab === eBodyweightInfoTab.Bodyweights) {
      this.selectedBodyweightGoalMenu = null;

      if (this.selectedBodyweightMenu === idx)
        this.selectedBodyweightMenu = null;
      else
        this.selectedBodyweightMenu = idx;
    }
    else if (this.selectedTab === eBodyweightInfoTab.Goals) {
      this.selectedBodyweightMenu = null;

      if (this.selectedBodyweightGoalMenu === idx)
        this.selectedBodyweightGoalMenu = null;
      else
        this.selectedBodyweightGoalMenu = idx;
    }

  }

  // methods

  editBodyweight(data: IWeightDto) {
    this.selectedBodyweightMenu = null;
    this.modalService.showEditBodyweightModal(data);
  }
  deleteBodyweight(id: number) {
    this.selectedBodyweightMenu = null;
    this.weightController.Remove(id).toPromise()
      .then(_ => this.bodyweightService.triggerBodyweights())
      .catch(ex => { throw ex; })
  }

  editBodyweightGoal(data: IWeightGoalDto) {
    this.selectedBodyweightGoalMenu = null;
    this.modalService.showEditBodyweightGoalModal(data);
  }
  deleteBodyweightGoal(id: number) {
    this.selectedBodyweightGoalMenu = null;
    this.weightGoalController.Remove(id).toPromise()
      .then(_ => this.bodyweightService.triggerBodyweights())
      .catch(ex => { throw ex; })
  }


  // private

  private getBodyweightGoals() {
    this.getPaginatedBodyweightGoals(this.bodyweightGoalsFirst, this.rows);
  }

  private getPaginatedBodyweightGoals(skip: number, take: number) {
    const options = {} as IWeightGoalSearchOptions;
    options.take = take;
    options.skip = skip;
    options.sortingOptions = [{ field: 'EndDate', dir: 'desc' }] as ISortingOptions[];

    this.weightGoalController.Search(options).toPromise()
      .then(_ => {
        if (_ !== null) {
          this.bodyweightGoals = _;
        }
      })
      .catch(ex => { throw ex; });
  }

  private getBodyweights() {
    this.getBodyweightsAndGoalsChart();
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

  private getBodyweightsAndGoalsChart() {
    this.destroyChart();

    const options = {} as IWeightSearchOptions;
    options.chartTimespanId = this.selectedTimespan;

    const goalOptions = {} as IWeightGoalSearchOptions;
    goalOptions.chartTimespanId = this.selectedTimespan;

    this.$q.all([
      this.weightController.Search(options).toPromise(),
      this.weightGoalController.Search(goalOptions).toPromise()
    ])
      .then(result => {
        if (result[0] !== null) {
          this.bodyweightsChart = result[0];
        }
        if (result[1] !== null) {
          this.bodyweightGoalsChart = result[1];
        }

        this.chartInit(this.selectedTarget);
        this.infoInit();
      })
  }

  private getStartDate() {
    const earliestTimestamp = new Date(
      Math.min(...this.bodyweightsChart.data.map(_ => new Date(_.logDate!).getTime()))
    );

    const earliestDate = new Date(earliestTimestamp.getTime() - earliestTimestamp.getTimezoneOffset() * 60000);
    return DateTime.fromJSDate(earliestDate);
  }

  private chartInit(target: TChartTarget) {
    if (this.chart)
      this.destroyChart();

    const today = DateTime.local().startOf('day');
    const startDate = (this.selectedTimespan !== eChartTimespan.AllTime
      ? today.minus({ months: this.selectedTimespan })
      : this.getStartDate())
      .minus({ days: 7 }); // padding for start of the chart

    const allDates: string[] = [];
    let totalDays = today.diff(startDate, 'days').days;
    let maxGoalEndDate = today;
    if (target === 'weight' && this.bodyweightGoalsChart?.data?.length) {
      const maxGoalEndDateTimespamp = new Date(
        Math.max(...this.bodyweightGoalsChart.data.map(_ => new Date(_.endDate).getTime()))
      );

      const maxGoalEndDateLocal = new Date(maxGoalEndDateTimespamp.getTime() - maxGoalEndDateTimespamp.getTimezoneOffset() * 60000);
      maxGoalEndDate = DateTime.fromJSDate(maxGoalEndDateLocal) as DateTime<true>;
    }

    maxGoalEndDate = maxGoalEndDate.plus({ days: 10 }); // padding for end of the chart
    totalDays = maxGoalEndDate.diff(startDate, 'days').days;
    for (let i = 0; i <= totalDays; i++) {
      const date = startDate.plus({ days: i });
      allDates.push(date.toFormat('MMM dd yyyy'));
    }

    const dataForChart: (number | null)[] = allDates.map(date => {
      // const formattedDate = DateTime.fromFormat(date, 'MMM ddd'); // this can be useful for year maybe (for all time showcase)

      const log = this.bodyweightsChart.data.find(_ => {
        const localDate = this.sharedService.getLocalDate(_.logDate);
        return DateTime.fromJSDate(localDate).toFormat('MMM dd yyyy') === date;
      });

      return log ? log[target]! : null;
    });

    const values = this.bodyweightsChart.data
      .map(_ => _[target]!)
      .filter(_ => _ !== undefined && _ !== null);

    // MAP GOALS

    const goalDatasets: any[] = [];
    const goalValues: number[] = [];

    if (target === 'weight' && this.bodyweightGoalsChart?.data) {
      const maxGoalWeight = Math.max(...this.bodyweightGoalsChart.data.map(_ => _.targetWeight));
      goalValues.push(maxGoalWeight);

      this.bodyweightGoalsChart.data.forEach((goal, idx) => {
        let goalData: (number | null)[] = new Array(allDates.length).fill(null);

        // End date
        const goalEndDate = DateTime.fromJSDate(new Date(goal.endDate)).toFormat('MMM dd yyyy');
        const endIdx = allDates.indexOf(goalEndDate);
        if (endIdx !== -1) goalData[endIdx] = goal.targetWeight;

        // Start date
        let goalStartWeight: number | null = null;
        const goalStartDate = DateTime.fromJSDate(new Date(goal.startDate)).toFormat('MMM dd yyyy');
        const startIdx = allDates.indexOf(goalStartDate);

        if (startIdx !== -1) {
          const log = this.bodyweightsChart.data.find(log =>
            DateTime.fromJSDate(this.sharedService.getLocalDate(log.logDate)).toFormat('MMM dd yyyy') === goalStartDate
          );
          goalStartWeight = log ? log[target]! : null; // setting a start of the goal to weight at that time
        }

        if (!goalStartWeight) {
          const closestLog = [...this.bodyweightsChart.data]
            .filter(log => this.sharedService.getLocalDate(log.logDate) < this.sharedService.getLocalDate(goal.startDate))
            .sort((a, b) =>
              DateTime.fromJSDate(this.sharedService.getLocalDate(b.logDate))
                .diff(DateTime.fromJSDate(this.sharedService.getLocalDate(a.logDate)), 'milliseconds')
                .milliseconds
            )[0];
          goalStartWeight = closestLog ? closestLog[target]! : null; // setting a start of the goal to closest weight at that time
        }

        if (startIdx !== -1 && goalStartWeight !== null) {
          goalData[startIdx] = goalStartWeight;
        }

        // Push a separate dataset for each goal
        goalDatasets.push({
          label: `Goal ${idx + 1}`,
          data: goalData,
          backgroundColor: 'rgba(255, 0, 0, 1)',
          borderColor: 'rgba(255, 0, 0, 1)',
          borderWidth: 2,
          borderDash: [10, 5],
          fill: false,
          tension: 0.3,
          spanGaps: true,
        });
      });
    }

    Chart.register(ChartDataLabels);

    this.chart = new Chart('bodyweights-line-chart', {
      type: 'line',
      data: {
        labels: allDates,
        datasets: [
          {
            label: target === 'weight' ? 'Bodyweight' : 'Body Fat',
            data: dataForChart,
            backgroundColor: 'rgba(0, 123, 255, 1)',
            borderColor: 'rgba(0, 123, 255, 1)',
            borderWidth: 2,
            tension: 0.3,
            spanGaps: true,
          },
          ...goalDatasets.map((dataset, idx) => ({
            ...dataset,
            datalabels: {
              display: true,
              align: 'top',
              anchor: 'end',
              formatter: (value: any, ctx: any) => {
                if (value === null) return '';

                const dataIdx = ctx.dataIndex;
                const firstIdx = dataset.data.findIndex((_: any) => _ !== null);
                const lastIdx = dataset.data.lastIndexOf(value);

                if (dataIdx === firstIdx)
                  return `Start`;
                else if (dataIdx === lastIdx)
                  return `Goal ${idx + 1}`

                return '';
              },
              color: 'rgba(255, 0, 0, 1)',
              font: {
                weight: 'bold',
                size: 12
              }
            }
          })),
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
            max: this.sharedService.roundToNearestTen(Math.round(Math.max(...values, ...goalValues) + 30)),
          },
        },
        plugins: {
          legend: {
            display: false,
          },
          datalabels: {
            display: false
          }
        }
      },
      plugins: [ChartDataLabels]
    });
  }

  private infoInit() {
    this.currentBodyweight.weight = this.bodyweightsChart?.data
      .filter(_ => _.weight !== undefined && _.weight !== null)
      .reduce((latest, current) => {
        const latestDate = new Date(latest.logDate!).getTime();
        const currentDate = new Date(current.logDate!).getTime();
        return currentDate > latestDate ? current : latest;
      }, this.bodyweightsChart.data[0]).weight!;

    this.currentBodyweight.weightUnitId = this.bodyweightsChart?.data
      .filter(_ => _.weight !== undefined && _.weight !== null)
      .reduce((latest, current) => {
        const latestDate = new Date(latest.logDate!).getTime();
        const currentDate = new Date(current.logDate!).getTime();
        return currentDate > latestDate ? current : latest;
      }, this.bodyweightsChart.data[0]).weightUnitId!;

    this.currentGoal.weight = this.bodyweightGoalsChart?.data
      .filter(_ => _.targetWeight !== undefined && _.targetWeight !== null)
      .reduce((latest, current) => {
        const latestDate = new Date(latest.endDate!).getTime();
        const currentDate = new Date(current.endDate!).getTime();
        return currentDate > latestDate ? current : latest;
      }, this.bodyweightGoalsChart.data[0]).targetWeight!;

    this.currentGoal.weightUnitId = this.bodyweightGoalsChart?.data
      .filter(_ => _.targetWeight !== undefined && _.targetWeight !== null)
      .reduce((latest, current) => {
        const latestDate = new Date(latest.endDate!).getTime();
        const currentDate = new Date(current.endDate!).getTime();
        return currentDate > latestDate ? current : latest;
      }, this.bodyweightGoalsChart.data[0]).weightUnitId!;

    this.currentBodyFat = this.bodyweightsChart?.data
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
