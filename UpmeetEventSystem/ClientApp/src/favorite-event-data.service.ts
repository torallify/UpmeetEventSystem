import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FavoriteEvent, JoinedEvent } from './app/interfaces/favorite';

@Injectable()
export class FavoriteEventDataService {
  userID: number;

  constructor(private http: HttpClient) {
    this.userID = Math.floor(Math.random() * 1000000) + 1;
    //this.userID = 13;
  }

  getFavoriteEvents() {
    return this.http.get<JoinedEvent[]>('/api/favorite/' + this.userID);
  }

  deleteFavoriteEvent(eventID: number) {
    return this.http.delete('/api/favorite/' + eventID);
  }

  postFavoriteEvent(eventID: number) {
    let event: FavoriteEvent = {
      id: 0,
      userID: this.userID,
      eventID: eventID
    };
    return this.http.post<FavoriteEvent>('/api/favorite', event);
  }
}
