import { Component, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'login',
    templateUrl: './loginLayout.component.html',
    styleUrls: ['./loginLayout.component.css']
  })

  export class LoginLayoutComponent implements OnInit {
  
    @Output()
    lightGreen : string = "#456063";

    @Output()
     darkGreen : string = "#384E52";

    @Output()
     registerColor: string = this.darkGreen;

    constructor(private httpClient : HttpClient){
  
    }
  
    async ngOnInit()
    {
       
    }

    onTabClicked(isOnRegister : boolean)
    {
       this.registerColor = (isOnRegister) ? this.lightGreen : this.darkGreen;
    }
  }