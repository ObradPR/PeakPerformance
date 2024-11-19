import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { PageLoaderComponent } from "./components/page-loader/page-loader.component";
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ToastModule, PageLoaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'PeakPerformance';

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.loadCurrentUser();
  }
}
