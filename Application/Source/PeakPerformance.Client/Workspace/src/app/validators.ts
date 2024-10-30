import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { DateTime } from 'luxon';

export function matchValues(matchTo: string, fieldName: string): ValidatorFn {
  return (control: AbstractControl) => {
    return control.value === control.parent?.get(matchTo)?.value
      ? null
      : {
          notMatching: {
            field: fieldName.capitalize(),
            matchingField: matchTo.capitalize(),
          },
        };
  };
}

export function minimumAgeValidator(minAge: number): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const value = control.value;
    if (!value) {
      return null;
    }

    const birthDate = DateTime.fromJSDate(value);

    const today = DateTime.now();

    const age = today.diff(birthDate, 'years').years;

    if (age >= minAge) {
      return null;
    } else {
      return { minimumAge: minAge };
    }
  };
}

export function goalStartDateValidator(): ValidatorFn {
  return (control: AbstractControl) => {
    if (!control.value) {
      return null;
    }

    const startDate = new Date(control.value);
    const today = new Date();

    const sixMonthsAgo = new Date(today);
    sixMonthsAgo.setMonth(today.getMonth() - 6);

    const sixMonthsFromNow = new Date(today);
    sixMonthsFromNow.setMonth(today.getMonth() + 6);

    if (startDate < sixMonthsAgo || startDate > sixMonthsFromNow) {
      return { dateOutOfRange: true };
    }

    return null;
  };
}

export function endDateAfterStartDate(
  startDateKey: string,
  endDateKey: string
): ValidatorFn {
  return (group: AbstractControl): ValidationErrors | null => {
    const startDate = group.get(startDateKey)?.value;
    const endDate = group.get(endDateKey)?.value;

    if (!startDate || !endDate) {
      return null;
    }

    const start = new Date(startDate);
    const end = new Date(endDate);

    return end > start ? null : { endDateBeforeStartDate: true };
  };
}
