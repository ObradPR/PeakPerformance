import { Injectable, signal } from '@angular/core';
import { IWeightDto, IWeightGoalDto } from '../_generated/interfaces';

export type TModal = 'add' | 'edit';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  // Bodyweight

  private bodyweightModal = signal<boolean>(false);
  private bodyweightModalType = signal<TModal | null>(null);
  private selectedBodyweight = signal<IWeightDto | null>(null);

  readonly bodyweightModalSignal = this.bodyweightModal.asReadonly();
  readonly bodyweightModalTypeSignal = this.bodyweightModalType.asReadonly();
  readonly selectedBodyweightSignal = this.selectedBodyweight.asReadonly();

  showAddBodyweightModal() {
    this.bodyweightModalType.set('add');
    this.bodyweightModal.set(true);
  }
  showEditBodyweightModal(data: IWeightDto) {
    this.bodyweightModalType.set('edit');
    this.selectedBodyweight.set(data);
    this.bodyweightModal.set(true);
  }
  hideBodyweightModal() {
    this.bodyweightModal.set(false);
    this.bodyweightModalType.set(null);
    this.selectedBodyweight.set(null);
  }

  // Bodyweight Goal

  private bodyweightGoalModal = signal<boolean>(false);
  private bodyweightGoalModalType = signal<TModal | null>(null);
  private selectedBodyweightGoal = signal<IWeightGoalDto | null>(null);

  readonly bodyweightGoalModalSignal = this.bodyweightGoalModal.asReadonly();
  readonly bodyweightGoalModalTypeSignal = this.bodyweightGoalModalType.asReadonly();
  readonly selectedBodyweightGoalSignal = this.selectedBodyweightGoal.asReadonly();

  showAddBodyweightGoalModal() {
    this.bodyweightGoalModalType.set('add');
    this.bodyweightGoalModal.set(true);
  }
  showEditBodyweightGoalModal(data: IWeightGoalDto) {
    this.bodyweightGoalModalType.set('edit');
    this.selectedBodyweightGoal.set(data);
    this.bodyweightGoalModal.set(true);
  }
  hideBodyweightGoalModal() {
    this.bodyweightGoalModal.set(false);
    this.bodyweightGoalModalType.set(null);
    this.selectedBodyweightGoal.set(null);
  }
}