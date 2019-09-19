import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { IMessage } from '../Chat/Message';


const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token',

    })
};


@Injectable()

export class ChatService
{
    submitUrl : string = "https://localhost:5001/api/chat";

    constructor(private http : HttpClient){ }


    public SendChatData(messageData : IMessage) : Observable<IMessage>
    {
        //remember to error handle
        return this.http.post<IMessage>(this.submitUrl, messageData, httpOptions);
    }
}