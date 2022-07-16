import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { PokerGame } from 'src/app/models/poker-game';
import { PokerAnalyzerService } from 'src/app/services/poker-analyzer.service';

@Component({
    changeDetection: ChangeDetectionStrategy.OnPush,
    selector: 'app-poker-game',
    templateUrl: './poker-game.component.html',
})
export class PokerGameComponent implements OnInit {

  @Input() public pokerGame: PokerGame;

  constructor(private _pokerAnalyzerService: PokerAnalyzerService) { }

  ngOnInit(): void {
    if(!this.pokerGame) {
      this._pokerAnalyzerService.getNewPokerGame();
    }
  }

}
