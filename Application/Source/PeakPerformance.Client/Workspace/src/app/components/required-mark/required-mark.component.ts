import { Component } from '@angular/core';

@Component({
  selector: 'app-required-mark',
  standalone: true,
  imports: [],
  template: `<span class="required-asterisk">*</span>`,
  styles: `.required-asterisk {
    color: red;
    font-weight: bold;
    margin-left: 0.2rem;
  }`,
})
export class RequiredMarkComponent {}
