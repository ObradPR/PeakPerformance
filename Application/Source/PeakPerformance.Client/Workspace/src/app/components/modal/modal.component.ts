import { Component } from '@angular/core';
import { ModalService } from '../../services/modal.service';
import { BodyweightModalComponent } from './bodyweight-modal/bodyweight-modal.component';


@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [BodyweightModalComponent],
  templateUrl: `./modal.component.html`,
  styles: ``
})
export class ModalComponent {
  constructor(public modalService: ModalService) { }
}
