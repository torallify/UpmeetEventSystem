import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { EventComponent } from './event/event.component';
import { FavoriteEventComponent } from './favorite-event/favorite-event.component';
import { EventDataService } from '../event-data.service';
import { FavoriteEventDataService } from '../favorite-event-data.service';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    EventComponent,
    FavoriteEventComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: EventComponent },
      { path: 'favorite', component: FavoriteEventComponent },
      { path: '**', component:PageNotFoundComponent}
      
    ])
  ],
  providers: [EventDataService, FavoriteEventDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
