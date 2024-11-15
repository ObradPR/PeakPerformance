import { Component } from '@angular/core';
import { LoaderService } from '../../services/loader.service';

@Component({
  selector: 'app-page-loader',
  standalone: true,
  imports: [],
  template: `
    @if (isVisible()) {
      <div class="backdrop">
        <span class="loader"></span>
      </div>
    }
  `,
  styleUrl: './page-loader.component.scss'
})
export class PageLoaderComponent {
  isVisible = this.loaderService.pageLoaderSignal;

  constructor(private loaderService: LoaderService) { }
}
