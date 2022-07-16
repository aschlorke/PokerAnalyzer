import { Component, Input, OnInit } from '@angular/core';
import { PokerGame } from 'src/app/models/poker-game';

@Component({
  selector: 'app-poker-game-ui',
  templateUrl: './poker-game.component.html',
  styleUrls: ['./poker-game.component.scss']
})
export class PokerGameComponentUI implements OnInit {

  @Input() public pokerGame: PokerGame;

  constructor() { }

  ngOnInit(): void {
  }

}
