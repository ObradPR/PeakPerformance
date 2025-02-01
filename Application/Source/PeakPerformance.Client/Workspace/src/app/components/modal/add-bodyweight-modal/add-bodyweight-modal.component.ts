import { CommonModule } from '@angular/common';
import { Component, output, OutputEmitterRef } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TooltipModule } from 'primeng/tooltip';
import { eMeasurementUnit } from '../../../_generated/enums';
import { IEnumProvider } from '../../../_generated/interfaces';
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

@Component({
  selector: 'app-add-bodyweight-modal',
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
  templateUrl: './add-bodyweight-modal.component.html',
  styleUrl: './add-bodyweight-modal.component.scss'
})
export class AddBodyweightModalComponent implements IModalMethods {
  closeModalEvent: OutputEmitterRef<boolean> = output<boolean>();
  form: FormGroup = this.fb.group({});

  weightUnits: IEnumProvider[] = [];

  constructor(
    private fb: FormBuilder,
    private referenceService: Providers,
    private toastService: ToastService,
    public loaderService: LoaderService,
    private weigthController: WeightController,
    private modalService: ModalService,
    private bodyweightService: BodyweightService
  ) {
    this.formInit();
  }

  closeModal(): void {
    this.closeModalEvent.emit(true);
  }

  formInit(): void {
    const date = new Date();
    date.setHours(0, 0, 0);

    this.form = this.fb.group({
      logDate: [date, Validators.required],
      weight: [null, [Validators.required, Validators.min(20.1), Validators.max(999.9)]],
      weightUnitId: [null, [Validators.required]],
      bodyFatPercentage: [null, [Validators.min(1.1), Validators.max(99.9)]],
    });

    this.referenceService.getMeasurementUnits()
      .map(_ => {
        if (_.id === eMeasurementUnit.Kilograms || _.id === eMeasurementUnit.Pounds)
          this.weightUnits.push(_);
      });
  }

  async addBodyweight() {
    if (this.form.invalid) {
      this.toastService.showFormError();
      return;
    }

    console.log(this.form.value);

    this.loaderService.showSectionLoader();

    this.weigthController.Add(this.form.value).toPromise()
      .then()
      .catch(ex => { throw ex; })
      .finally(() => {
        this.loaderService.hideSectionLoader();
        this.bodyweightService.triggerBodyweights();
        this.modalService.hideAddBodyweightModal();
      });
  }
}
