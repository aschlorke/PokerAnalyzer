import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { PokerGame } from 'src/app/models/poker-game';

@Component({
  selector: 'app-poker-game-ui',
  templateUrl: './poker-game.component.html',
  styleUrls: ['./poker-game.component.scss']
})
export class PokerGameComponentUI implements OnInit, OnChanges {

  // for testing, collapse when done
  @Input() public pokerGame: PokerGame;

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    if (this.pokerGame) {
      console.log(this.pokerGame);
    }
  }

}
