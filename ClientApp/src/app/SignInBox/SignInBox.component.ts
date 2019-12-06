import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService, ILoginForm } from '../Services/user.service';
import { Router } from '@angular/router';



@Component({
    selector: 'sign-in-box',
    templateUrl: './SignInBox.component.html',
    styleUrls: ['./SignInBox.component.css'],
    providers: [ UserService ]
  })

  export class SignInComponent implements OnInit {
  
    loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });


    constructor(private httpClient : HttpClient,
               private userService : UserService,
               private router: Router){
  
    }
  
    async ngOnInit()
    {
       
    }

    onSubmit()
    {
      var loginForm : ILoginForm = {
        username: this.loginForm.get("username").value,
        password: this.loginForm.get("password").value
      };

      this.userService.Login(loginForm).subscribe(
        result => {         
          if (result) {
            //  console.log(result);
             this.router.navigate(['/feed']);            
          }
        });

    }


  }