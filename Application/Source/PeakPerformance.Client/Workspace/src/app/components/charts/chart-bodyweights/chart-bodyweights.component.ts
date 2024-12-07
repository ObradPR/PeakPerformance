import { Component, input, OnChanges, SimpleChanges } from '@angular/core';
import {
  ApexAnnotations,
  ApexAxisChartSeries,
  ApexChart,
  ApexTitleSubtitle,
  ApexXAxis,
  NgApexchartsModule
} from "ng-apexcharts";
import { IPagingResult, IWeightDto } from '../../../_generated/interfaces';
import { IDataPoint } from '../data-point.interface';

@Component({
  selector: 'app-chart-bodyweights',
  standalone: true,
  imports: [NgApexchartsModule],
  templateUrl: './chart-bodyweights.component.html',
  styles: ``
})
export class ChartBodyweightsComponent implements OnChanges {
  bodyweights = input<IPagingResult<IWeightDto>>();

  // Chart components should be made to work for preview and for a full view 
  series!: ApexAxisChartSeries;
  chart!: ApexChart;
  xaxis!: ApexXAxis;
  title!: ApexTitleSubtitle;
  annotations!: ApexAnnotations;

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['bodyweights'])
      this.chartInit();
  }

  private chartInit() {
    this.seriesDataInit();
    this.annotationsDataInit();

    this.chart = {
      height: 200,
      type: 'area',
      zoom: {
        enabled: true,
        type: 'x',
        autoScaleYaxis: true
      },
      toolbar: {
        show: false
      },
    };

    this.xaxis = {
      type: 'datetime'
    };

    this.title = {
      text: 'Bodyweights in last 7 days',
      align: 'left',
      style: {
        color: '#343A40',
        fontSize: '14px',
        fontFamily: 'Roboto, sans-serif',
        fontWeight: '500'
      }
    };
  }

  private seriesDataInit() {
    const seriesData: IDataPoint[] = [];
    this.bodyweights()?.data
      .filter(_ => _.weight !== undefined)
      .forEach(_ =>
        seriesData.push({ x: new Date(_.createdOn).getTime(), y: _.weight ?? 100 })
      );

    this.series = [
      {
        name: "Bodyweight",
        data: seriesData
      }
    ];
  }

  private annotationsDataInit() {
    const total = this.bodyweights()?.data
      .filter(_ => _.weight !== undefined)
      .reduce((sum, _) => sum + (_.weight ?? 0), 0);

    if (total !== undefined) {
      const average = total / this.bodyweights()!.data.length;
      this.annotations = {
        yaxis: [
          {
            y: average,
            borderColor: '#20C997',
            label: {
              borderColor: '#20C997',
              style: {
                color: '#fff',
                background: '#20C997'
              },
              text: `Average ${average.toFixed(0)}`,
            }
          }
        ]
      }
    }
  }
}