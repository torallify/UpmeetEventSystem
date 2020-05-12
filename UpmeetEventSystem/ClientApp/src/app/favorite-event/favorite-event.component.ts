import { Component } from '@angular/core';
import { EventDataService } from '../../event-data.service';
import { FavoriteEventDataService } from '../../favorite-event-data.service';
import { JoinedEvent } from '../interfaces/favorite';

@Component({
    selector: 'app-favorite-event',
    templateUrl: './favorite-event.component.html',
    styleUrls: ['./favorite-event.component.scss']
})

export class FavoriteEventComponent {

  constructor(private eventData: EventDataService,
    private favoriteEventData: FavoriteEventDataService) { }

  favoriteEvents: JoinedEvent[];

  ngOnInit() {
    this.get();
  }

  delete(id: number) {
    this.favoriteEventData.deleteFavoriteEvent(id).subscribe(
      (data: any) => {
        console.log(data);
        this.get();
      },
      error => console.error(error)
    );
  }

  get() {
    this.favoriteEventData.getFavoriteEvents().subscribe(
      (data: JoinedEvent[]) => {
        this.favoriteEvents = data;
      },
      error => console.error(error)
    );
  }
}
