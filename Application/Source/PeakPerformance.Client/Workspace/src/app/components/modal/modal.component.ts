import { Component } from '@angular/core';
import { ModalService } from '../../services/modal.service';
import { BodyweightModalComponent } from './bodyweight-modal/bodyweight-modal.component';
import { BodyweightGoalModalComponent } from './bodyweight-goal-modal/bodyweight-goal-modal.component';


@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [
    BodyweightModalComponent,
    BodyweightGoalModalComponent
  ],
  templateUrl: `./modal.component.html`,
  styles: ``
})
export class ModalComponent {
  constructor(public modalService: ModalService) { }
}
