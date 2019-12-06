import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';
import { SearchService } from '../Services/search.service';
import { UserService, IRegisterForm } from '../Services/user.service';

@Component({
    selector: 'sign-up-box',
    templateUrl: './SignUpBox.component.html',
    styleUrls: ['./SignUpBox.component.css'],
    providers: [ UserService ]
  })



  export class SignUpComponent implements OnInit {
  
    registerForm = new FormGroup({
        email: new FormControl(''),
        username: new FormControl(''),
        password: new FormControl(''),
        displayName: new FormControl('')

    });
    constructor(private httpClient : HttpClient,
              private userService: UserService)
    {
  
    }
  
    async ngOnInit()
    {
       
    }

    onSubmit()
    {
      console.log("submitted");
      
       var registerForm : IRegisterForm = {
          username: this.registerForm.get("username").value,
          email: this.registerForm.get("email").value,
          password: this.registerForm.get("password").value,
          displayName: this.registerForm.get("displayName").value
       };

       this.userService.Register(registerForm).subscribe((res) => {
        console.log(res);});
       
    }


  }