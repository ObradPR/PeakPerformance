import { AbstractControl, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { DateTime } from 'luxon';
import { Constants } from './constants';
import { inject } from '@angular/core';
import { Providers } from './_generated/providers';

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
      return { dateOutOfRange: true }
    }

    return null;
  };
}

export function injuryStartDateValidator(): ValidatorFn {
  return (control: AbstractControl) => {
    if (!control.value) {
      return null;
    }

    const startDate = new Date(control.value);
    const today = new Date();

    const yearAgo = new Date(today);
    yearAgo.setFullYear(today.getFullYear() - 1);

    const yearFromNow = new Date(today);
    yearFromNow.setFullYear(today.getFullYear() + 1);

    if (startDate < yearAgo || startDate > yearFromNow) {
      return { dateOutOfRange: true }
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

export function socialMediaValidator(platformIdKey: string, linkKey: string, phoneKey: string): ValidatorFn {
  return (formGroup: AbstractControl): { [key: string]: any } | null => {
    const platformId = formGroup.get(platformIdKey)?.value;
    const link = formGroup.get(linkKey);
    const phoneNumber = formGroup.get(phoneKey);

    if (platformId && platformId.type === 'phone') {
      link?.setValidators(null);
      phoneNumber?.setValidators([Validators.required, Validators.pattern(Constants.REGEX_PHONE_NUMBER)]);
    } else if ((platformId && platformId.type === 'link')) {
      link?.setValidators([Validators.required, Validators.maxLength(255)]);
      phoneNumber?.setValidators(null);
    }

    return null;
  };
}

export function platformLinkValidator(
  platformIdKey: string,
  linkKey: string,
  phoneKey: string,
  referenceService: Providers
): ValidatorFn {
  return (formGroup: AbstractControl): ValidationErrors | null => {
    const platform = formGroup.get(platformIdKey)?.value;
    const linkValue = formGroup.get(linkKey)?.value;
    const link = formGroup.get(linkKey);
    const phoneNumber = formGroup.get(phoneKey);

    if (platform && platform.type === 'link' && linkValue !== null) {
      phoneNumber?.setValidators(null);

      const platformName = referenceService.getSocialMediaPlatforms()
        .find(_ => _.id === +platform.id)?.name.toLowerCase();

      const isValidLink = linkValue.startsWith('https://') && linkValue.includes(platformName);


      if (!isValidLink) {
        link?.setErrors({ invalidPlatformLink: true });
      } else {
        link?.setErrors(null);
      }
    }

    if (!platform || !linkValue) {
      return null;
    }

    return null;


  };
}