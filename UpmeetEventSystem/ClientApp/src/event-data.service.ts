import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Event } from './app/interfaces/event';

@Injectable()
export class EventDataService {
    
  constructor(private http: HttpClient) { }

  async getEvents() {
    return this.http.get<Event[]>('/api/event').toPromise();
  }

  async addNewEvent(event:Event) {
    
    return this.http.post<number>('/api/event', event).toPromise();
  }


}
