import { Component, Input, OnInit } from '@angular/core';
import { PokerGame } from 'src/app/models/poker-game';
import { PokerAnalyzerService } from 'src/app/services/poker-analyzer.service';

@Component({
  selector: 'app-poker-game',
  templateUrl: './poker-game.component.html',
  styleUrls: ['./poker-game.component.scss']
})
export class PokerGameComponentUI implements OnInit {

  @Input() public pokerGame: PokerGame;

  constructor(private _pokerAnalyzerService: PokerAnalyzerService) { }

  ngOnInit(): void {
    if(!this.pokerGame) {
      this._pokerAnalyzerService.getNewPokerGame();
    }
  }

}
