import { Component, Input } from '@angular/core';
import { ITag } from './tag';

@Component({
  selector: 'tag',
  template: `<div [style.fontSize] = 'fontSize' 
                  [style.color] = 'textColor'
                  [style.float] = 'floatDir' 
                  [style.fontWeight] = 'fontWeight'
                  class = 'tag'> {{ tagName }} </div>`,
  styles: [`
    :host
    {
        margin:0px 1px;
    }

    .tag:first-child
    {
        margin-left: 4px;
    }

    .tag {
        border-radius: 5px;
        border: 1px solid darkgreen;
        background: rgba(16, 54, 59, 0.845);
        white-space: nowrap;
        color: white;
        text-align: center;
        padding: 0.4em 0.8em;
        font-size: 12px;
        
    }
`],
})

export class TagComponent implements ITag{

    @Input()
    fontWeight: string = 'initial';
    
    @Input()
    fontSize: string = '12px';

    @Input()
    textColor: string = 'white';
    
    @Input()
    floatDir: string;

     @Input()
     tagName: string;

     description: string;
     followerCount: number;
}