import { Component } from '@angular/core';
import { ModalService } from '../../services/modal.service';
import { AddBodyweightModalComponent } from './add-bodyweight-modal/add-bodyweight-modal.component';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [AddBodyweightModalComponent],
  templateUrl: `./modal.component.html`,
  styles: ``
})
export class ModalComponent {
  constructor(public modalService: ModalService) {
    this.modalService.showAddBodyweightModal();
  }
}
