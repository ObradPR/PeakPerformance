import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../services/shared.service';
import { AccountSetupComponent } from './account-setup/account-setup.component';
import { LeftMenuComponent } from "./left-menu/left-menu.component";
import { UserPanelComponent } from "./user-panel/user-panel.component";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-hub',
  standalone: true,
  imports: [AccountSetupComponent, LeftMenuComponent, UserPanelComponent, RouterOutlet],
  templateUrl: './hub.component.html',
  styleUrl: './hub.component.scss',
})
export class HUBComponent implements OnInit {

  constructor(public sharedService: SharedService) { }

  ngOnInit(): void { }
}
