import { Component } from '@angular/core';
import { EventDataService } from '../../event-data.service';
import { FavoriteEventDataService } from '../../favorite-event-data.service';

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

  events: Event[];

  ngOnInit() {
    this.eventData.getEvents().subscribe(
      (data: Event[]) => {
        this.events = data;
      },
      error => console.error(error)
    );
  }

  add(id: number) {
    this.favoriteEventData.postFavoriteEvent(id).subscribe(
      (data: any) => console.log('success! ' + id), //TODO: change the button
      error => console.error(error)
    )
  }
}
