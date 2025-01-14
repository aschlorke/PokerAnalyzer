import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PokerGameResultsComponent } from './poker-game-results.component';

describe('PokerGameResultsComponent', () => {
  let component: PokerGameResultsComponent;
  let fixture: ComponentFixture<PokerGameResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PokerGameResultsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PokerGameResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
