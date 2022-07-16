import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PokerGame } from 'src/app/models/poker-game';
import { PokerAnalyzerService } from 'src/app/services/poker-analyzer.service';

@Component({
  selector: 'app-poker-game',
  template: `
        <app-poker-game-ui
            [pokerGame]="pokerGame$ | async"
        >    
    `,
})
export class PokerGameComponent implements OnInit {

  pokerGame$: Observable<PokerGame>;

  constructor(private _pokerAnalyzerService: PokerAnalyzerService) { }

  ngOnInit(): void {
    this.pokerGame$ = this._pokerAnalyzerService.getNewPokerGame();
  }
}
