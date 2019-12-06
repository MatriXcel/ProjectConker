import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { ISearchResult } from '../SearchResults/SearchResult/searchResult';
import { Observable } from 'rxjs';


const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
};

export interface IAccountInfo
{
    displayName : string;
}
 
export interface ILoginForm
{
    username: string;
    password: string;
}

export interface IRegisterForm extends ILoginForm
{
    email: string;
    displayName: string;
}

@Injectable()

export class UserService {

    accountsUrl: string = "/api/accounts";
    username : string = "";
    loggedIn : boolean = false;

    constructor(private http: HttpClient) { }

    public GetAccountInfo() : Observable<any>
    {
        const headers = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('auth_token')});
        return this.http.get(this.accountsUrl + "/info", {headers});
    }

    public Register(registerForm : IRegisterForm) : Observable<IRegisterForm>
    {
        return this.http.post<IRegisterForm>(this.accountsUrl + "/register", registerForm, httpOptions);
    }

    public IsLoggedIn()
    {
        return !!localStorage.getItem("auth_token");
        
    }

    public Login(loginForm : ILoginForm) : Observable<ILoginForm>
    {
        return this.http.post<ILoginForm>(this.accountsUrl + "/login", loginForm, httpOptions)
        .pipe(map<any, any>((data, index) => {

            localStorage.setItem("auth_token", data.token);
            
            this.username = data.username;
            console.log(data);
            return data;

        }));
    }
}