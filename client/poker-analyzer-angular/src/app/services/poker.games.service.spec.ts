import { TestBed } from '@angular/core/testing';

import { PokerGamesService } from './poker-games.service';

describe('PokerGamesService', () => {
  let service: PokerGamesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PokerGamesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
