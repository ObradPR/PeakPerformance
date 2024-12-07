import { Component, input, OnChanges, SimpleChanges } from '@angular/core';
import { Constants } from '../../../constants';
import { BaseChartComponent } from '../_base/base-chart.component';
import { IAreaChartOptions } from '../interfaces/area-chart-options.interface';
import { IDataPoint } from '../interfaces/data-point.interface';
import { NgApexchartsModule } from 'ng-apexcharts';

@Component({
  selector: 'app-area-chart',
  standalone: true,
  imports: [NgApexchartsModule],
  templateUrl: './area-chart.component.html',
  styles: ``
})
export class AreaChartComponent extends BaseChartComponent implements OnChanges {
  areaChartOptions = input<IAreaChartOptions>();

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['data'])
      this.chartInit();
  }

  chartInit(): void {
    if (!this.data() || !this.areaChartOptions()?.xField || !this.areaChartOptions()?.yField)
      return;

    // Series

    const seriesData: IDataPoint[] = [];
    this.data()?.data
      .filter(_ => _[this.areaChartOptions()!.yField] !== undefined)
      .forEach(_ =>
        seriesData.push({
          x: new Date(_[this.areaChartOptions()!.xField]).getTime(),
          y: _[this.areaChartOptions()!.yField] ?? this.areaChartOptions()?.yFieldDefaultValue
        })
      );

    this.series = [
      {
        name: this.seriesName(),
        data: seriesData
      }
    ];

    // Annotations

    if (this.hasAnnotations()) {
      const total = this.data()?.data
        .filter(_ => _[this.areaChartOptions()!.yField] !== undefined)
        .reduce((sum, _) => sum + (_[this.areaChartOptions()!.yField] ?? 0), 0);

      if (total !== undefined) {
        const average = total / this.data()!.data.length;
        this.annotations = {
          yaxis: [
            {
              y: average,
              borderColor: Constants.TEAL_HEX,
              label: {
                borderColor: Constants.TEAL_HEX,
                style: {
                  color: Constants.WHITE_HEX,
                  background: Constants.TEAL_HEX
                },
                text: `Average ${average.toFixed(0)}`,
              }
            }
          ]
        }
      }
    }


    // Chart

    this.chart = {
      height: this.areaChartOptions()?.height ?? 200,
      type: 'area',
      zoom: {
        enabled: true,
        type: 'x',
        autoScaleYaxis: true
      },
      toolbar: {
        show: this.areaChartOptions()?.showToolbar
      },
    };

    // Xaxis 

    this.xaxis = {
      type: this.areaChartOptions()?.xType ?? 'datetime'
    };

    // Title

    if (this.hasTitle()) {
      this.title = {
        text: this.titleText(),
        align: 'left',
        style: this.titleStyle()
      };
    }
  }
}
