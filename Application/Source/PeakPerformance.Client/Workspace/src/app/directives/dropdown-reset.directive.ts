// import { Directive, HostListener, inject, Input } from '@angular/core';
// import { NgControl } from '@angular/forms';

// @Directive({
//   selector: '[appDropdownReset]',
//   standalone: true
// })
// export class DropdownResetDirective {
//   @Input() appDropdownReset: number | null = 0;

//   private ngControl = inject(NgControl);

//   @HostListener('change', ['$event'])
//   onChange(event: any): void {
//     console.log(event);
//     const selectedValue = event.value;
//     if (selectedValue === this.appDropdownReset) {
//       this.ngControl.control?.setValue(null);
//     }
//   }
// }

import { Directive, Input } from '@angular/core';
import { NgControl } from '@angular/forms';
import { Dropdown } from 'primeng/dropdown';

@Directive({
  selector: '[appDropdownReset]',
  standalone: true
})
export class DropdownResetDirective {
  @Input() appDropdownReset: number | null = 0;

  constructor(
    private ngControl: NgControl,
    private dropdown: Dropdown
  ) { }

  ngOnInit() {
    // Subscribe to PrimeNG's onChange event
    this.dropdown.onChange.subscribe((event: any) => {
      const selectedValue = event.value;
      if (selectedValue === this.appDropdownReset) {
        this.ngControl.control?.setValue(null);
      }
    });
  }
}