export interface FavoriteEvent {
  id: number;
  userID: number;
  eventID: number;
}

export interface JoinedEvent {
  id: number;
  userID: number;
  eventID: number;
  eventName: string;
  topic: string;
  description: string;
  location: string;
}
