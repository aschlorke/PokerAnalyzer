import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PokerGameComponent } from './poker-game.component.presentation';

describe('PokerGameComponent', () => {
  let component: PokerGameComponent;
  let fixture: ComponentFixture<PokerGameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PokerGameComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PokerGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
