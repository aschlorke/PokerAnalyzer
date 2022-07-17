import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PokerHomeComponent } from './poker-home.component.container';

describe('PokerHomeComponent', () => {
  let component: PokerHomeComponent;
  let fixture: ComponentFixture<PokerHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PokerHomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PokerHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
