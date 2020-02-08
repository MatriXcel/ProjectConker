import { Component, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { FormGroup, FormControl } from '@angular/forms';
import { FormService } from '../Services/form.service';
import { IChatForm } from './chatForm';

@Component({
    selector: 'create-chat',
    templateUrl: './createChat.component.html',
    styleUrls: ['./createChat.component.css'],
    providers: [ FormService ]

  })

  export class CreateChatComponent implements OnInit  {

      constructor(private formService : FormService<IChatForm>) { }


      createChatForm = new FormGroup({
          title: new FormControl(''),
          description: new FormControl(''),
          tags: new FormControl('A-New-Earth Spirituality')
      });

      createChatUrl : string = '/api/chat/create';
      ngOnInit()
      {
         console.log("initialized");
      }

      sendCreateChatData() : void
      {
          var formData : IChatForm = {
              title: this.createChatForm.get("title").value,
              description: this.createChatForm.get("description").value,
              tags: this.createChatForm.get("tags").value
          };
          
          console.log(this.createChatForm.get("tags").value);

          this.formService.SendFormData(this.createChatUrl, formData).subscribe();
      }  

      onSubmit(){
          console.log("wooow");
          this.sendCreateChatData();
      }
    
  }