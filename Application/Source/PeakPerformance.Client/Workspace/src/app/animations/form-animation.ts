import {
  animate,
  query,
  stagger,
  style,
  transition,
  trigger,
} from '@angular/animations';

export const formAnimation = trigger('formAnimation', [
  transition(':enter', [
    query('.form-row', [
      style({ opacity: 0, transform: 'scale(0.7)' }),
      stagger(150, [
        animate('0.15s', style({ opacity: 1, transform: 'scale(1)' })),
      ]),
    ]),
  ]),
  transition(':leave', [
    query('.form-row', [
      stagger(150, [
        animate('0.15s', style({ opacity: 0, transform: 'scale(0.7)' })),
      ]),
    ]),
  ]),
]);
