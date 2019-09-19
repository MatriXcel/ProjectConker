import { Component, Input, OnInit } from '@angular/core';
import { ISearchResult } from './searchResult';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'searchresult',
  templateUrl: './searchResult.component.html',
  styleUrls: ['./searchResult.component.css']
})

export class SearchResultComponent implements ISearchResult, OnInit {

    author: string;

    iconLink: string;

    @Input()
    title: string;

    @Input()
    authorName: string;

    @Input()
    summary: string;

    @Input()
    tags: string[];


    constructor(private http : HttpClient){}

    private getRandomUser()
    {
      this.http.get("https://randomuser.me/api/")
      .subscribe(
        (data: any) => {

           this.iconLink = data.results[0].picture.medium;
           this.author = data.results[0].name.first;
        }
      );

    }

    ngOnInit() {
        this.getRandomUser();
    }
}