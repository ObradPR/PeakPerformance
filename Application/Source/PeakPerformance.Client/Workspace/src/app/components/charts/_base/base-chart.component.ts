import { Component, input } from '@angular/core';
import {
  ApexAnnotations,
  ApexAxisChartSeries,
  ApexChart,
  ApexTitleSubtitle,
  ApexXAxis,
  NgApexchartsModule
} from "ng-apexcharts";
import { IPagingResult } from '../../../_generated/interfaces';
import { ITitleStyle } from '../interfaces/title-style.interface';
import { Constants } from '../../../constants';

@Component({
  selector: 'app-base-chart',
  standalone: true,
  imports: [NgApexchartsModule],
  template: ``,
  styles: ``
})
export abstract class BaseChartComponent {
  data = input<IPagingResult<any>>(); // any should cover all Dtos
  seriesName = input<string>('');
  titleText = input<string>('');
  titleStyle = input<ITitleStyle>({
    color: Constants.DARK_GREY_HEX,
    fontSize: '14px',
    fontFamily: Constants.APP_FONT,
    fontWeight: '500'
  });

  hasTitle = input<boolean>(false);
  hasAnnotations = input<boolean>(false);

  chart!: ApexChart;
  series!: ApexAxisChartSeries;
  xaxis!: ApexXAxis;
  title: ApexTitleSubtitle;
  annotations: ApexAnnotations;


  abstract chartInit(): void;
}
