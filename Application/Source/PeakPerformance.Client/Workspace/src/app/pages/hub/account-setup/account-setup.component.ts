import { CommonModule } from '@angular/common';
import { Component, OnInit, Renderer2 } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { FileSelectEvent, FileUploadModule } from 'primeng/fileupload';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { StepperModule } from 'primeng/stepper';
import { TooltipModule } from 'primeng/tooltip';
import { RequiredMarkComponent } from '../../../components/required-mark/required-mark.component';
import { Constants } from '../../../constants';
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
    TooltipModule,
    CommonModule,
    FileUploadModule,
    InputTextareaModule,
  ],
  templateUrl: './account-setup.component.html',
  styleUrl: './account-setup.component.scss',
})
export class AccountSetupComponent implements OnInit {
  form: FormGroup = this.fb.group({});
  maxProfilePictureSize = Constants.IMAGE_MAX_SIZE_BYTE;
  uploadedPicture: any = null;

  constructor(private fb: FormBuilder, private renderer: Renderer2) {}

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
        weight: [null, [Validators.min(20.1), Validators.max(999.9)]],
        weightUnitId: [null, [Validators.required]],
        bodyFatPercentage: [null, [Validators.min(1.1), Validators.max(99.9)]],
      }),
      bodyMeasurement: this.fb.group({
        waist: [null, [Validators.min(20.1), Validators.max(999.9)]],
        hips: [null, [Validators.min(20.1), Validators.max(999.9)]],
        neck: [null, [Validators.min(20.1), Validators.max(999.9)]],
        chest: [null, [Validators.min(20.1), Validators.max(999.9)]],
        shoulders: [null, [Validators.min(20.1), Validators.max(999.9)]],
        rightBicep: [null, [Validators.min(20.1), Validators.max(999.9)]],
        leftBicep: [null, [Validators.min(20.1), Validators.max(999.9)]],
        rightForearm: [null, [Validators.min(20.1), Validators.max(999.9)]],
        leftForearm: [null, [Validators.min(20.1), Validators.max(999.9)]],
        rightThigh: [null, [Validators.min(20.1), Validators.max(999.9)]],
        leftThigh: [null, [Validators.min(20.1), Validators.max(999.9)]],
        rightCalf: [null, [Validators.min(20.1), Validators.max(999.9)]],
        leftCalf: [null, [Validators.min(20.1), Validators.max(999.9)]],
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
            [Validators.required, Validators.min(20.1), Validators.max(999.9)],
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
            [Validators.required, Validators.min(1.1), Validators.max(99.9)],
          ],
          startDate: [
            null,
            [Validators.required, validators.goalStartDateValidator()],
          ],
          endDate: [null, [Validators.required]],
        },
        { validators: validators.endDateAfterStartDate('startDate', 'endDate') }
      ),
      image: [null],
      description: [null, [Validators.maxLength(500)]],
      receiveNews: [false],
    });
  }

  onProfilePictureSelect(event: FileSelectEvent) {
    console.log(event);
    const file = event.currentFiles[0];
    this.form.patchValue({ image: file });
  }

  onSubmit() {
    console.log(this.form.invalid ? 'nevalja' : 'valja');
    console.log(this.form.value);
  }
}
