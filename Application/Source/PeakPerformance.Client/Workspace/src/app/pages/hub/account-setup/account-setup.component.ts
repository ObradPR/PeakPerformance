import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { StepperModule } from 'primeng/stepper';
import { RequiredMarkComponent } from '../../../components/required-mark/required-mark.component';
import { InputTextModule } from 'primeng/inputtext';

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
  ],
  templateUrl: './account-setup.component.html',
  styleUrl: './account-setup.component.scss',
})
export class AccountSetupComponent {
  cities: any;

  selectedCity: any;

  ngOnInit() {
    this.cities = [
      { name: 'New York', code: 'NY' },
      { name: 'Rome', code: 'RM' },
      { name: 'London', code: 'LDN' },
      { name: 'Istanbul', code: 'IST' },
      { name: 'Paris', code: 'PRS' },
    ];
  }
}
