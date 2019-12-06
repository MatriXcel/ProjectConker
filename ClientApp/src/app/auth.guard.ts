import { Injectable, Component } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { UserService } from './Services/user.service';



@Injectable({
    providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  constructor(private user: UserService, private router: Router) {}

  canActivate() {

    if(!this.user.IsLoggedIn())
    {
       console.log("yeep");
       this.router.navigate(['/signin']);
       return false;
    }

    return true;
  }
}