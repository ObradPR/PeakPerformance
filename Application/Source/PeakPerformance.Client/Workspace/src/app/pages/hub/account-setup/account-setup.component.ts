import { CommonModule } from '@angular/common';
import { Component, OnInit, Renderer2 } from '@angular/core';
import {
  FormArray,
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
import { InputMaskModule } from 'primeng/inputmask';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { StepperModule } from 'primeng/stepper';
import { TooltipModule } from 'primeng/tooltip';
import { Providers } from '../../../_generated/providers';
import { RequiredMarkComponent } from '../../../components/required-mark/required-mark.component';
import { Constants } from '../../../constants';
import * as validators from '../../../validators';
import { UserService } from '../../../services/user.service';
import { ToastService } from '../../../services/toast.service';
import { IEnumProvider } from '../../../_generated/interfaces';
import { DropdownResetDirective } from '../../../directives/dropdown-reset.directive';
import { eMeasurementUnit, eSocialMediaPlatform } from '../../../_generated/enums';
import { SharedService } from '../../../services/shared.service';

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
    InputMaskModule,
    DropdownResetDirective
  ],
  templateUrl: './account-setup.component.html',
  styleUrl: './account-setup.component.scss',
})
export class AccountSetupComponent implements OnInit {
  form: FormGroup = this.fb.group({});
  maxProfilePictureSize = Constants.IMAGE_MAX_SIZE_BYTE;
  uploadedPicture: any = null;
  eSocialMediaPlatform = eSocialMediaPlatform;

  weightPreferenceUnits: IEnumProvider[] = [];
  measurementPreferenceUnits: IEnumProvider[] = [];
  trainingGoals: IEnumProvider[] = [];
  platforms: IEnumProvider[] = [];
  injuries: IEnumProvider[] = [];

  constructor(
    private fb: FormBuilder,
    private referenceService: Providers,
    private userService: UserService,
    private toastService: ToastService,
    private sharedService: SharedService
  ) { }


  ngOnInit() {
    this.formInit();
    this.formDataInit();
  }

  get socialMedia(): FormArray {
    return this.form.get('socialMedia') as FormArray;
  }

  get healthInformation(): FormArray {
    return this.form.get('healthInformation') as FormArray;
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
      socialMedia: this.fb.array([]),
      healthInformation: this.fb.array([]),
    });
  }

  createSocialMediaItem(): FormGroup {
    return this.fb.group(
      {
        platformId: [null],
        link: [null],
        phoneNumber: [null]
      },
      {
        validators: Validators.compose([
          validators.socialMediaValidator('platformId', 'link', 'phoneNumber'),
          validators.platformLinkValidator('platformId', 'link', 'phoneNumber', this.referenceService)
        ])
      }
    );
  }

  addSocialMediaItem() {
    this.socialMedia.push(this.createSocialMediaItem());
  }

  removeSocialMediaItem(index: number) {
    this.socialMedia.removeAt(index);
  }

  createHealthInformationItem(): FormGroup {
    return this.fb.group(
      {
        injuryTypeId: [null, [Validators.required]],
        description: [null, [Validators.required]],
        startDate: [null, [validators.injuryStartDateValidator()]],
        endDate: [null]
      },
      { validators: validators.endDateAfterStartDate('startDate', 'endDate') }
    );
  }

  addHealthInformationItem() {
    this.healthInformation.push(this.createHealthInformationItem());
  }

  removeHealthInformationItem(index: number) {
    this.healthInformation.removeAt(index);
  }

  onProfilePictureSelect(event: FileSelectEvent) {
    const file = event.currentFiles[0];
    this.form.patchValue({ image: file });
  }

  async onSubmit() {
    if (this.form.invalid) {
      this.toastService.showFormError();
      return;
    }

    const formData = this.createFormData(this.form.value);
    this.userService.profileSetup(formData).toPromise()
      .catch(ex => { throw ex; })
      .finally(() => {
        this.toastService.showGeneralSuccess();
        this.sharedService.setFromSignupSignal(false);
      });
  }

  private createFormData(formValue: any): FormData {
    const formData = new FormData();

    this.appendFormFields(formData, formValue);
    return formData;
  }

  private appendFormFields(formData: FormData, formValues: any, parentKey: string = '') {
    for (const key in formValues) {
      if (formValues[key] !== null && formValues[key] !== undefined) {
        const formKey = parentKey ? `${parentKey}.${key}` : key;

        if (formValues[key] instanceof File) {
          formData.append(formKey, formValues[key]);
        } else if (Array.isArray(formValues[key])) {
          formValues[key].forEach((value: any, index: any) => {
            this.appendFormFields(formData, value, `${formKey}[${index}]`);
          });
        } else if (formValues[key] instanceof Date) {
          formData.append(formKey, formValues[key].toISOString());
        } else if (typeof formValues[key] === 'object') {
          this.appendFormFields(formData, formValues[key], formKey);
        } else {
          formData.append(formKey, formValues[key]);
        }
      }
    }
  }

  private formDataInit() {
    this.trainingGoals = this.referenceService.getTrainingGoals();
    this.platforms = this.referenceService.getSocialMediaPlatforms();
    this.injuries = this.referenceService.getInjuryTypes();

    this.referenceService.getMeasurementUnits()
      .map(_ => {
        if (_.id === eMeasurementUnit.NotSet) {
          this.measurementPreferenceUnits.push(_);
          this.weightPreferenceUnits.push(_);
        }
        else if (_.id === eMeasurementUnit.Kilograms || _.id === eMeasurementUnit.Pounds) {
          this.weightPreferenceUnits.push(_);
        }
        else {
          this.measurementPreferenceUnits.push(_);
        }
      });
  }
}
