import { Pipe, PipeTransform } from '@angular/core';
import { Providers } from '../_generated/providers';
import { eMeasurementUnit } from '../_generated/enums';

@Pipe({
  name: 'measurementUnitDescription',
  standalone: true
})
export class MeasurementUnitDescriptionPipe implements PipeTransform {

  constructor(private referenceService: Providers) { }

  transform(unitId?: eMeasurementUnit): string {
    if (!unitId) return '';

    return this.referenceService.getMeasurementUnits().find(_ => _.id === unitId)?.description || '';
  }

}
