
import { Component, OnInit } from '@angular/core';
import { ITag } from '../Tag/tag';
import { TagComponent } from '../Tag/tag.component';
import { Router, ActivatedRoute, ParamMap, Params } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { IMessage } from './Message';
import { HubConnection, HubConnectionBuilder, HttpTransportType } from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'chat',
  templateUrl: "./chatComponent.component.html",
  styleUrls: ['./chatComponent.component.css']
  // providers: [ ChatService ]
})

export class ChatComponent implements OnInit {

  hubConnection: HubConnection;

  messageData: IMessage;
  message: string;

  //profile info
  author: string;
  iconLink: string;

  messages: IMessage[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) { }

  ngOnInit() {

    this.getRandomUser();

    this.hubConnection = new HubConnectionBuilder().withUrl("https://localhost:5001/api/chat", {
      skipNegotiation: true,
      transport: HttpTransportType.WebSockets
    }).build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this.hubConnection.on('ReceiveMessage', (author: string, receivedMessage: IMessage) => {

      this.messages.push(receivedMessage);
    });

  }

  private getRandomUser() {
    this.http.get("https://randomuser.me/api/")
      .subscribe(
        (data: any) => {
          console.log(data);

          this.iconLink = data.results[0].picture.medium;
          this.author = data.results[0].name.first;

          console.log(this.iconLink);
        }
      );

  }

  public sendMessage(): void {

    var today = new Date();

    this.messageData = {
      author: this.author,
      message: this.message,
      timestamp: ("0" + today.getHours()).toString().slice(-2) + ":" + ("0" + today.getMinutes()).toString().slice(-2),
      iconLink: this.iconLink
    };
    this.hubConnection
      .invoke('SendToAll', this.author, this.messageData)
      .catch(err => console.error(err));

    this.message = '';
  }


}