import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { PokerGame } from 'src/app/models/poker-game';

@Component({
  selector: 'app-poker-game',
  templateUrl: './poker-game.component.html',
  styleUrls: ['./poker-game.component.scss']
})
export class PokerGameComponent implements OnInit, OnChanges {

  @Input() public currentGame: PokerGame;

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
  }

}
