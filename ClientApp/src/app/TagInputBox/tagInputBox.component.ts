import { FormControl, ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Router } from '@angular/router';
import { Component, forwardRef, Output, Input } from '@angular/core';

@Component({
    selector: 'tag-input-box',
    templateUrl: './tagInputBox.component.html',
    styleUrls: ['./tagInputBox.component.css'],
    
    providers: [
        { 
          provide: NG_VALUE_ACCESSOR,
          useExisting: forwardRef(() => TagInputBoxComponent),
          multi: true
        }
      ]
  })
  
  export class TagInputBoxComponent implements ControlValueAccessor {
  
       tagList: string[] = ['sql-server', 'c-sharp', 'game-dev'];
       tagInput : FormControl = new FormControl('');
      
       @Input()
       inputPlaceholder : string;


       constructor() { }
      

       onSpacePressed(event: KeyboardEvent) {
          
        this.tagList.push(this.tagInput.value);
        this.onChange(this.tagList.join(' '));
        this.tagInput.setValue('');
        
      }
  
      onChange = (newTags: string) => {};
  
      onBackPressed(event: KeyboardEvent)
      {
           this.tagList.pop();
      }


      registerOnChange(fn : (newTags: string) => void) {
         this.onChange = fn;
      }
    
      registerOnTouched(fn) { 
        //this.onTouched = fn;
      }

      writeValue(value) {
          this.tagList = value.split(' ');
          this.onChange(value);
      }
}

