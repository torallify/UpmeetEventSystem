/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { FavoriteEventComponent } from './favorite-event.component';

let component: FavoriteEventComponent;
let fixture: ComponentFixture<FavoriteEventComponent>;

describe('favoriteEvent component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ FavoriteEventComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(FavoriteEventComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});