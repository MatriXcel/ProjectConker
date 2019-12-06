import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { ISearchResult } from '../SearchResults/SearchResult/searchResult';
import { Observable } from 'rxjs';




const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
};


@Injectable()
  
export class SearchService {

    searchUrl: string = "/api/search?q=";

    constructor(private http: HttpClient) { }

    public GetSearchResult(query: string) : Observable<ISearchResult[]>
    {
      //remember to do error handling
      
          return this.http.get<ISearchResult[]>(this.searchUrl + query);
    }
}