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



@NgModule({
  declarations: [
    ChatComponent, SiteHeaderComponent, SiteLayoutComponent, SiteSideNavComponent, SignUpComponent,
    AppComponent, FeedComponent, SearchbarComponent, SignInComponent,
    TagComponent, TagInputBoxComponent, TagSearchComponent,
    SearchResultComponent, SearchResultsComponent, LoginLayoutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {
        path: '',
        component: SiteLayoutComponent,
        children: [
          { path: 'feed', component: FeedComponent },
          { path: 'search', component: SearchResultsComponent },
    
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
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
