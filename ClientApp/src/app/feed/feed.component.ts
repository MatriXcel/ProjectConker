import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css'],
})
export class FeedComponent implements OnInit {
  title = 'Feed';

  constructor(private httpClient : HttpClient){

  }

  async ngOnInit()
  {
      
  }
}
