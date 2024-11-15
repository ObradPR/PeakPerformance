import { Component } from '@angular/core';
import { LoaderService } from '../../services/loader.service';

@Component({
  selector: 'app-section-loader',
  standalone: true,
  imports: [],
  template: `
    @if (isVisible()) {
      <div class="wrapper">
        <span class="loader"></span>
      </div>
    }
  `,
  styleUrl: './section-loader.component.scss'
})
export class SectionLoaderComponent {
  isVisible = this.loaderService.sectionLoaderSignal;

  constructor(private loaderService: LoaderService) { }
}
