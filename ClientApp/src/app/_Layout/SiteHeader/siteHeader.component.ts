import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'site-header',
  templateUrl: './siteHeader.component.html',
  styleUrls: ['./siteHeader.component.css']
})

export class SiteHeaderComponent {
  displayName = '';

  constructor(private httpClient : HttpClient, private userService : UserService){

  }

  async ngOnInit()
  {
      this.userService.GetAccountInfo().subscribe((data) => {
           this.displayName = data.displayName;
      });
  }
}