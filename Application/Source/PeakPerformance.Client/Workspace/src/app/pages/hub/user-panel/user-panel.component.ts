import { Component } from '@angular/core';
import { BadgeModule } from 'primeng/badge';

@Component({
  selector: 'app-user-panel',
  standalone: true,
  imports: [BadgeModule],
  templateUrl: './user-panel.component.html',
  styleUrl: './user-panel.component.scss'
})
export class UserPanelComponent {
  notificationBadgeValue: string = '1';
}
