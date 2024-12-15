import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  private addBodyweightModal = signal<boolean>(false);

  readonly addBodyweightModalSignal = this.addBodyweightModal.asReadonly();

  showAddBodyweightModal() {
    this.addBodyweightModal.set(true);
  }

  hideAddBodyweightModal() {
    this.addBodyweightModal.set(false);
  }
}
