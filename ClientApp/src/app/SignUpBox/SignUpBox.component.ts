import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
    selector: 'sign-up-box',
    templateUrl: './SignUpBox.component.html',
    styleUrls: ['./SignUpBox.component.css']
  })

  export class SignUpComponent implements OnInit {
  
    registerForm = new FormGroup({
        email: new FormControl(''),
        username: new FormControl(''),
        password: new FormControl(''),
        repeatPassword: new FormControl('')

    });
    constructor(private httpClient : HttpClient){
  
    }
  
    async ngOnInit()
    {
       
    }
  }