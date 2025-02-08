import { CommonModule } from '@angular/common';
import { Component, output, OutputEmitterRef } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TooltipModule } from 'primeng/tooltip';
import { IWeightGoalDto } from '../../../_generated/interfaces';
import { WeightGoalController } from '../../../_generated/services';
import { BodyweightService } from '../../../services/bodyweight.service';
import { LoaderService } from '../../../services/loader.service';
import { ModalService } from '../../../services/modal.service';
import { SharedService } from '../../../services/shared.service';
import { ToastService } from '../../../services/toast.service';
import { RequiredMarkComponent } from '../../required-mark/required-mark.component';
import { SectionLoaderComponent } from '../../section-loader/section-loader.component';
import { IModalMethods } from '../interfaces/modal-methods.interface';

@Component({
  selector: 'app-bodyweight-goal-modal',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    InputTextModule,
    TooltipModule,
    CalendarModule,
    RequiredMarkComponent,
    DropdownModule,
    SectionLoaderComponent
  ],
  templateUrl: './bodyweight-goal-modal.component.html',
  styleUrl: './bodyweight-goal-modal.component.scss'
})
export class BodyweightGoalModalComponent implements IModalMethods {
  closeModalEvent: OutputEmitterRef<boolean> = output<boolean>();
  form: FormGroup = this.fb.group({});
  selectedBodyweightGoal: IWeightGoalDto | null = null;

  constructor(
    private fb: FormBuilder,
    private toastService: ToastService,
    public loaderService: LoaderService,
    private weigthGoalController: WeightGoalController,
    public modalService: ModalService,
    private bodyweightService: BodyweightService,
    private sharedService: SharedService
  ) {
    this.selectedBodyweightGoal = this.modalService.selectedBodyweightGoalSignal();
    this.formInit();
  }

  closeModal(): void {
    this.closeModalEvent.emit(true);
  }

  formInit(): void {
    const startDate = this.selectedBodyweightGoal?.startDate
      ? new Date(this.selectedBodyweightGoal!.startDate)
      : null;
    const startLocalDate = startDate ? this.sharedService.getLocalDate(startDate) : null;
    if (startLocalDate)
      startLocalDate.setHours(0, 0, 0);

    const endDate = this.selectedBodyweightGoal?.endDate
      ? new Date(this.selectedBodyweightGoal?.endDate)
      : null;
    const endLocalDate = endDate ? this.sharedService.getLocalDate(endDate) : null;
    if (endLocalDate)
      endLocalDate.setHours(0, 0, 0);

    this.form = this.fb.group({
      startDate: [startLocalDate, Validators.required],
      endDate: [endLocalDate, Validators.required],
      targetWeight: [this.selectedBodyweightGoal?.targetWeight ?? null, [Validators.required, Validators.min(20.1), Validators.max(999.9)]],
    });
  }

  submitBodyweightGoal() {
    if (this.form.invalid) {
      this.toastService.showFormError();
      return;
    }

    this.loaderService.showSectionLoader();

    if (this.selectedBodyweightGoal !== null)
      this.form.value.id = this.selectedBodyweightGoal.id;

    const method = this.modalService.bodyweightGoalModalTypeSignal() === 'add'
      ? this.weigthGoalController.Add(this.form.value)
      : this.weigthGoalController.Edit(this.form.value);

    method.toPromise()
      .then()
      .catch(ex => { throw ex; })
      .finally(() => {
        this.loaderService.hideSectionLoader();
        // this.bodyweightService.triggerBodyweights();
        this.modalService.hideBodyweightGoalModal();
      });
  }
}
