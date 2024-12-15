import { Component, output, OutputEmitterRef } from '@angular/core';
import { IModalMethods } from '../interfaces/modal-methods.interface';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { TooltipModule } from 'primeng/tooltip';
import { CommonModule } from '@angular/common';
import { CalendarModule } from 'primeng/calendar';
import { RequiredMarkComponent } from '../../required-mark/required-mark.component';
import { DropdownResetDirective } from '../../../directives/dropdown-reset.directive';
import { DropdownModule } from 'primeng/dropdown';
import { IEnumProvider } from '../../../_generated/interfaces';
import { Providers } from '../../../_generated/providers';
import { eMeasurementUnit } from '../../../_generated/enums';

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
    DropdownModule
  ],
  templateUrl: './add-bodyweight-modal.component.html',
  styleUrl: './add-bodyweight-modal.component.scss'
})
export class AddBodyweightModalComponent implements IModalMethods {
  closeModalEvent: OutputEmitterRef<boolean> = output<boolean>();
  form: FormGroup = this.fb.group({});

  weightUnits: IEnumProvider[] = [];

  constructor(private fb: FormBuilder, private referenceService: Providers) {
    this.formInit();
  }

  closeModal(): void {
    this.closeModalEvent.emit(true);
  }

  formInit(): void {
    this.form = this.fb.group({
      logDate: [null, Validators.required],
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
}
