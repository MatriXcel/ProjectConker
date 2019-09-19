import { Component, OnInit } from '@angular/core';
import { ITag } from '../../Tag/tag';
import { TagComponent } from '../../Tag/tag.component';
import { Router, ActivatedRoute, ParamMap, Params } from '@angular/router';
import { switchMap } from 'rxjs/operators';
// import { SearchService } from '../../Services/search.service';
import { Observable } from 'rxjs';
import { ISearchResult } from '../SearchResult/searchResult';
import { SearchService } from 'src/app/Services/search.service';



@Component({
  templateUrl:"./searchResults.component.html",
  styleUrls: ['./searchResults.component.css'],
  providers: [ SearchService ]
})

export class SearchResultsComponent implements OnInit {

  searchResults: ISearchResult[];
  query: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private searchService: SearchService,
  ) {}

  ngOnInit() {

       this.route.queryParams.subscribe( (params: Params) => {
          this.searchService.GetSearchResult(params['q']).subscribe((data : ISearchResult[]) => {
             this.searchResults = data;
             console.log(this.searchResults);
          });
      } );
     
  }

}