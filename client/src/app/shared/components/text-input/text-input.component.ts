import { Component, OnInit, Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.scss']
})
export class TextInputComponent implements ControlValueAccessor, OnInit {

  @Input() type = 'text';
  @Input() label = '';

  constructor(@Self() public controlDir: NgControl) {
    this.controlDir.valueAccessor = this;
   }

  ngOnInit(): void {
  }

  writeValue(obj: any): void {
  }

  registerOnChange(fn: any): void {    
  }

  registerOnTouched(fn: any): void {    
  }

  get control(): FormControl{
    return this.controlDir.control as FormControl;
  }

}
