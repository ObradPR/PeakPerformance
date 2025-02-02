import { CommonModule } from '@angular/common';
import { Component, output, OutputEmitterRef } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TooltipModule } from 'primeng/tooltip';
import { eMeasurementUnit } from '../../../_generated/enums';
import { IEnumProvider, IWeightDto } from '../../../_generated/interfaces';
import { Providers } from '../../../_generated/providers';
import { WeightController } from '../../../_generated/services';
import { DropdownResetDirective } from '../../../directives/dropdown-reset.directive';
import { BodyweightService } from '../../../services/bodyweight.service';
import { LoaderService } from '../../../services/loader.service';
import { ModalService } from '../../../services/modal.service';
import { ToastService } from '../../../services/toast.service';
import { RequiredMarkComponent } from '../../required-mark/required-mark.component';
import { SectionLoaderComponent } from '../../section-loader/section-loader.component';
import { IModalMethods } from '../interfaces/modal-methods.interface';
import { SharedService } from '../../../services/shared.service';

@Component({
  selector: 'app-bodyweight-modal',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    InputTextModule,
    TooltipModule,
    CalendarModule,
    RequiredMarkComponent,
    DropdownResetDirective,
    DropdownModule,
    SectionLoaderComponent
  ],
  templateUrl: './bodyweight-modal.component.html',
  styleUrl: './bodyweight-modal.component.scss'
})
export class BodyweightModalComponent implements IModalMethods {
  closeModalEvent: OutputEmitterRef<boolean> = output<boolean>();
  form: FormGroup = this.fb.group({});
  selectedBodyweight: IWeightDto | null = null;

  weightUnits: IEnumProvider[] = [];

  constructor(
    private fb: FormBuilder,
    private referenceService: Providers,
    private toastService: ToastService,
    public loaderService: LoaderService,
    private weigthController: WeightController,
    public modalService: ModalService,
    private bodyweightService: BodyweightService,
    private sharedService: SharedService
  ) {
    this.selectedBodyweight = this.modalService.selectedBodyweightSignal();
    this.formInit();
  }

  closeModal(): void {
    this.closeModalEvent.emit(true);
  }

  formInit(): void {
    const date = new Date(this.selectedBodyweight?.logDate ?? Date.now());
    const localDate = this.sharedService.getLocalDate(date);
    localDate.setHours(0, 0, 0);

    console.log(date);

    this.form = this.fb.group({
      logDate: [localDate, Validators.required],
      weight: [this.selectedBodyweight?.weight ?? null, [Validators.required, Validators.min(20.1), Validators.max(999.9)]],
      weightUnitId: [this.selectedBodyweight?.weightUnitId ?? null, [Validators.required]],
      bodyFatPercentage: [this.selectedBodyweight?.bodyFatPercentage ?? null, [Validators.min(1.1), Validators.max(99.9)]],
    });

    this.referenceService.getMeasurementUnits()
      .map(_ => {
        if (_.id === eMeasurementUnit.Kilograms || _.id === eMeasurementUnit.Pounds)
          this.weightUnits.push(_);
      });
  }

  submitBodyweight() {
    if (this.form.invalid) {
      this.toastService.showFormError();
      return;
    }

    this.loaderService.showSectionLoader();

    if (this.selectedBodyweight !== null)
      this.form.value.id = this.selectedBodyweight.id;

    const method = this.modalService.bodyweightModalTypeSignal() === 'add'
      ? this.weigthController.Add(this.form.value)
      : this.weigthController.Edit(this.form.value);

    method.toPromise()
      .then()
      .catch(ex => { throw ex; })
      .finally(() => {
        this.loaderService.hideSectionLoader();
        this.bodyweightService.triggerBodyweights();
        this.modalService.hideBodyweightModal();
      });
  }
}
