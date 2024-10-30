import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { StepperModule } from 'primeng/stepper';
import { RequiredMarkComponent } from '../../../components/required-mark/required-mark.component';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import * as validators from '../../../validators';

@Component({
  selector: 'app-account-setup',
  standalone: true,
  imports: [
    StepperModule,
    ButtonModule,
    DropdownModule,
    FormsModule,
    RequiredMarkComponent,
    InputTextModule,
    ReactiveFormsModule,
    CalendarModule,
  ],
  templateUrl: './account-setup.component.html',
  styleUrl: './account-setup.component.scss',
})
export class AccountSetupComponent implements OnInit {
  form: FormGroup = this.fb.group({});

  constructor(private fb: FormBuilder) {}

  // =============
  cities: any;

  selectedCity: any;

  ngOnInit() {
    this.cities = [
      { name: 'New York', code: 'NY' },
      { name: 'Rome', code: 'RM' },
      { name: 'London', code: 'LDN' },
      { name: 'Istanbul', code: 'IST' },
      { name: 'Paris', code: 'PRS' },
    ];

    // ===============

    this.formInit();
  }

  private formInit() {
    this.form = this.fb.group({
      weight: this.fb.group({
        weight: [null, [Validators.min(21), Validators.max(999)]],
        weightUnitId: [null, [Validators.required]],
        bodyFatPercentage: [null, [Validators.min(2), Validators.max(99)]],
      }),
      bodyMeasurement: this.fb.group({
        waist: [null, [Validators.min(21), Validators.max(999)]],
        hips: [null, [Validators.min(21), Validators.max(999)]],
        neck: [null, [Validators.min(21), Validators.max(999)]],
        chest: [null, [Validators.min(21), Validators.max(999)]],
        shoulders: [null, [Validators.min(21), Validators.max(999)]],
        rightBicep: [null, [Validators.min(21), Validators.max(999)]],
        leftBicep: [null, [Validators.min(21), Validators.max(999)]],
        rightForearm: [null, [Validators.min(21), Validators.max(999)]],
        leftForearm: [null, [Validators.min(21), Validators.max(999)]],
        rightThigh: [null, [Validators.min(21), Validators.max(999)]],
        leftThigh: [null, [Validators.min(21), Validators.max(999)]],
        rightCalf: [null, [Validators.min(21), Validators.max(999)]],
        leftCalf: [null, [Validators.min(21), Validators.max(999)]],
        measurementUnitId: [null, [Validators.required]],
      }),
      userTrainingGoal: this.fb.group(
        {
          trainingGoalId: [null, [Validators.required]],
          startDate: [
            null,
            [Validators.required, validators.goalStartDateValidator()],
          ],
          endDate: [null],
        },
        { validators: validators.endDateAfterStartDate('startDate', 'endDate') }
      ),
      weightGoal: this.fb.group(
        {
          targetWeight: [
            null,
            [Validators.required, Validators.min(21), Validators.max(999)],
          ],
          startDate: [
            null,
            [Validators.required, validators.goalStartDateValidator()],
          ],
          endDate: [null, [Validators.required]],
        },
        { validators: validators.endDateAfterStartDate('startDate', 'endDate') }
      ),
      bodyFatGoal: this.fb.group(
        {
          targetBodyFatPercentage: [
            null,
            [Validators.required, Validators.min(2), Validators.max(99)],
          ],
          startDate: [
            null,
            [Validators.required, validators.goalStartDateValidator()],
          ],
          endDate: [null, [Validators.required]],
        },
        { validators: validators.endDateAfterStartDate('startDate', 'endDate') }
      ),
    });
  }

  onSubmit() {
    console.log(this.form.invalid ? 'nevalja' : 'valja');
    console.log(this.form.value);
  }
}
