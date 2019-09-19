import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';



@Component({
    selector: 'sign-in-box',
    templateUrl: './SignInBox.component.html',
    styleUrls: ['./SignInBox.component.css']
  })

  export class SignInComponent implements OnInit {
  
    loginForm = new FormGroup({
      username: new FormControl('', Validators.required, ),
      password: new FormControl('', Validators.required)
    });


    constructor(private httpClient : HttpClient){
  
    }
  
    async ngOnInit()
    {
       
    }

    onSubmit()
    {
      console.log('hmmm');
    }


  }