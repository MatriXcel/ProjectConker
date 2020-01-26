import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { ISearchResult } from '../SearchResults/SearchResult/searchResult';
import { Observable } from 'rxjs';
import { IChatForm } from '../CreateChat/chatForm';




const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
};


@Injectable()
  
export class FormService<T> {

    constructor(private http: HttpClient) { }

    public SendFormData<T>(postUrl : string, data : T)
    {
        return this.http.post<T>(postUrl, data, httpOptions);
    }
}