import { Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.scss'],
})
export class TextInputComponent implements ControlValueAccessor {
  @Input() type = 'text';
  @Input() label = '';

  // Angular tries to reuse services that have been injected from memory.
  // @Self decorator makes this injection unique for every instance of this component.
  // NgControl is a base class that all FormControl based directives extend. It binds a FormControl object to a DOM element
  constructor(@Self() public controlDir: NgControl) {
    this.controlDir.valueAccessor = this;
  }

  writeValue(obj: any): void {}
  registerOnChange(fn: any): void {}
  registerOnTouched(fn: any): void {}

  // We'll use this rather than controlDir directly to prevent TS errors
  get control(): FormControl {
    return this.controlDir.control as FormControl;
  }
}
