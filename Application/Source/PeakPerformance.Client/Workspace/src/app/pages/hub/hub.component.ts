import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../services/shared.service';
import { AccountSetupComponent } from './account-setup/account-setup.component';

@Component({
  selector: 'app-hub',
  standalone: true,
  imports: [AccountSetupComponent],
  templateUrl: './hub.component.html',
  styleUrl: './hub.component.scss',
})
export class HUBComponent implements OnInit {

  constructor(public sharedService: SharedService) { }

  ngOnInit(): void { }
}
