import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../services/shared.service';
import { AccountSetupComponent } from './account-setup/account-setup.component';
import { LeftMenuComponent } from "./left-menu/left-menu.component";
import { UserPanelComponent } from "./user-panel/user-panel.component";
import { RouterOutlet } from '@angular/router';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { MenuItem } from 'primeng/api';
import { ModalComponent } from '../../components/modal/modal.component';

@Component({
  selector: 'app-hub',
  standalone: true,
  imports: [
    AccountSetupComponent,
    LeftMenuComponent,
    UserPanelComponent,
    RouterOutlet,
    BreadcrumbModule,
    ModalComponent
  ],
  templateUrl: './hub.component.html',
  styleUrl: './hub.component.scss',
})
export class HUBComponent implements OnInit {
  breadcrumbItemHome: MenuItem = { icon: 'pi pi-home', routerLink: '/' };

  constructor(public sharedService: SharedService) {
    this.sharedService.pushBreadcrumbItem({ label: 'Dashboard', routerLink: '/hub' });
  }

  ngOnInit(): void { }
}
