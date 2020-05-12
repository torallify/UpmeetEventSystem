import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EventDataService {
  constructor(private http: HttpClient) { }

  getEvents() {
    return this.http.get<Event[]>('/api/event');
  }
}
