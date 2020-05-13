import { Component } from '@angular/core';
import { EventDataService } from '../../event-data.service';
import { FavoriteEventDataService } from '../../favorite-event-data.service';
import { Event } from '../interfaces/event';
import { JoinedEvent } from '../interfaces/favorite';

@Component({
    selector: 'app-event',
    templateUrl: './event.component.html',
    styleUrls: ['./event.component.scss']
})
/** event component*/
export class EventComponent {
    /** event ctor */
  constructor(private eventData: EventDataService,
    private favoriteEventData: FavoriteEventDataService) { }
  newName: string;
  newTopic: string;
  newDescription: string;
  newLocation: string;
  events: Event[];
  favoritesFlag: boolean = false;

  ngOnInit() {
    //this.eventData.getEvents().subscribe(
    //  (data: any) => {
    //    this.events = data;
    //  },
    //  error => console.error(error)
    //);
    this.updateEvents()
  }
  async updateEvents() {
    this.events =  await this.eventData.getEvents()
    }

  add(id: number) {
    this.favoriteEventData.postFavoriteEvent(id).subscribe(
      (data: any) => console.log('success! ' + id), //TODO: change the button
      error => console.error(error)
    )
  }

  async addNewEvent() {
    await this.eventData.addNewEvent({ eventName: this.newName, topic: this.newTopic, description: this.newDescription, location: this.newLocation } as Event)
    this.updateEvents()
    this.newName = ""
    this.newTopic = ""
    this.newDescription = ""
    this.newLocation = ""
  }

  addedToFavoritesFlag = function (): void {
    this.favoritesFlag = !this.favoritesFlag;
  }
}
