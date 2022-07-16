import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayingCardListComponent } from './playing-card-list.component';

describe('PlayingCardListComponent', () => {
  let component: PlayingCardListComponent;
  let fixture: ComponentFixture<PlayingCardListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlayingCardListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayingCardListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
