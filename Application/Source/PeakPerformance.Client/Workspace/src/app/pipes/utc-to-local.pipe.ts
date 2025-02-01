import { Pipe, PipeTransform } from '@angular/core';
import { DateTime } from 'luxon';

@Pipe({
  name: 'utcToLocal',
  standalone: true
})
export class UtcToLocalPipe implements PipeTransform {

  transform(value: string | Date, format: string = 'MMM dd yyyy'): string {
    if (!value) return '';

    return DateTime.fromISO(value.toString(), { zone: 'utc' })
      .toLocal()
      .toFormat(format);
  }

}
