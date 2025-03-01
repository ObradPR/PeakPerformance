import { Pipe, PipeTransform } from '@angular/core';
import { eMeasurementUnit } from '../_generated/enums';
import { Functions } from '../functions';
import { AuthService } from '../services/auth.service';

@Pipe({
  name: 'measurementConverter',
  standalone: true
})
export class MeasurementConverterPipe implements PipeTransform {

  constructor(private authService: AuthService) { }

  transform(value?: number, valueUnit?: eMeasurementUnit): string {
    if (value == null) return '';
    if (valueUnit == null) return value.toString();

    const user = this.authService.currentUserSource();
    const weightPreference = user?.weightUnitId;
    const measurementPreference = user?.measurementUnitId;

    const conversions: Partial<Record<eMeasurementUnit, () => string>> = {
      [eMeasurementUnit.Kilograms]: () =>
        weightPreference === eMeasurementUnit.Pounds
          ? `${Functions.toPounds(value)} lbs`
          : `${value} kg`,

      [eMeasurementUnit.Pounds]: () =>
        weightPreference === eMeasurementUnit.Kilograms
          ? `${Functions.toKilograms(value)} kg`
          : `${value} lbs`,

      [eMeasurementUnit.Centimeters]: () =>
        measurementPreference === eMeasurementUnit.Inches
          ? `${Functions.toInches(value)} in`
          : `${value} cm`,

      [eMeasurementUnit.Inches]: () =>
        measurementPreference === eMeasurementUnit.Centimeters
          ? `${Functions.toCentimeters(value)} cm`
          : `${value} in`,
    };

    return conversions[valueUnit]?.() ?? value.toString();
  }

}
