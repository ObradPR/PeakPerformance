import {
  animate,
  query,
  stagger,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Constants } from '../constants';

export const formAnimation = trigger('formAnimation', [
  transition(':enter', [
    query('.form-row', [
      style({ opacity: 0, transform: 'scale(0.7)' }),
      stagger(Constants.FORM_ANIMATION_PERIOD, [
        animate(
          Constants.FORM_ANIMATION_PERIOD,
          style({ opacity: 1, transform: 'scale(1)' })
        ),
      ]),
    ]),
  ]),
  transition(':leave', [
    query('.form-row', [
      stagger(Constants.FORM_ANIMATION_PERIOD, [
        animate(
          Constants.FORM_ANIMATION_PERIOD,
          style({ opacity: 0, transform: 'scale(0.7)' })
        ),
      ]),
    ]),
  ]),
]);
