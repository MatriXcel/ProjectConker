import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { FeedComponent } from './feed/feed.component';

import { SiteHeaderComponent } from './_Layout/SiteHeader/siteHeader.component';
import { SiteLayoutComponent } from './_Layout/SiteLayout/siteLayout.component';
import { SiteSideNavComponent } from './_Layout/SiteSideNav/siteSideNav.component';

import { SignUpComponent } from './SignUpBox/SignUpBox.component';
import { SignInComponent } from './SignInBox/SignInBox.component';
import { LoginLayoutComponent } from './_Layout/LoginLayout/loginLayout.component';

import { SearchResultComponent } from './SearchResults/SearchResult/searchResult.component';
import { SearchResultsComponent } from './SearchResults/SearchResults/searchResults.component';

import { ChatComponent } from './Chat/chatComponent.component';
import { SearchbarComponent } from './Searchbar/searchbar.component';

import { TagComponent } from './Tag/tag.component';
import { TagInputBoxComponent } from './TagInputBox/tagInputBox.component';
import { TagSearchComponent } from './TagSearch/tagSearch.component';
import { AuthGuard } from './auth.guard';
import { UserService } from './Services/user.service';
import { ChatroomsComponent } from './ChatroomsRelated/Chatrooms/chatrooms.component';
import { ChatroomsLayoutComponent } from './_Layout/ChatroomsLayout/chatroomsLayout.component';
import { CreateChatComponent } from './CreateChat/createChat.component';
import { ChatroomComponent } from './ChatroomsRelated/Chatroom/chatroom.component';



@NgModule({
  declarations: [
    ChatComponent, SiteHeaderComponent, SiteLayoutComponent, SiteSideNavComponent, SignUpComponent,
    AppComponent, FeedComponent, SearchbarComponent, SignInComponent,
    TagComponent, TagInputBoxComponent, TagSearchComponent,
    SearchResultComponent, SearchResultsComponent, LoginLayoutComponent, ChatroomsComponent,
    ChatroomsLayoutComponent, CreateChatComponent, ChatroomComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

    RouterModule.forRoot([
      {
        path: '',
        component: SiteLayoutComponent, canActivate: [AuthGuard],
        children: [
          { path: 'feed', component: FeedComponent },
          { path: 'search', component: SearchResultsComponent },
          { 
            path: 'chatrooms', 
            component: ChatroomsLayoutComponent,
            children: [
              { path: '', component: ChatroomsComponent },
              { path: 'create', component: CreateChatComponent }
            ]
          },
          { path: '', redirectTo: '/feed', pathMatch: 'full' }
        ]
      },
    
      {
        path: '',
        component: LoginLayoutComponent,
        children: [
          { path: 'signin', component: SignInComponent },
          { path: 'signup', component: SignUpComponent }
        ]
      },
    
      { path: 'chat', component: ChatComponent },
    ])
  ],
  providers: [
    UserService,
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
