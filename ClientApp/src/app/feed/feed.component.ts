import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService, IAccountInfo } from '../Services/user.service';


@Component({
  selector: 'feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css'],
  providers: [ UserService ]
})


export class FeedComponent implements OnInit {
  title = 'Feed';
  displayName = '';

  constructor(private httpClient : HttpClient, private userService : UserService){

  }

  async ngOnInit()
  {
      this.userService.GetAccountInfo().subscribe((data) => {
      });
  }
}
