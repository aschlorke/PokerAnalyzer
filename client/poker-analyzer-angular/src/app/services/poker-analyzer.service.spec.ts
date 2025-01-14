import { TestBed } from '@angular/core/testing';

import { PokerAnalyzerService } from './poker-analyzer.service';

describe('PokerAnalyzerService', () => {
  let service: PokerAnalyzerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PokerAnalyzerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
