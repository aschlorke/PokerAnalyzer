import { Component, Input, OnInit } from '@angular/core';
import { PokerGameResults } from 'src/app/models/poker-game-results';

@Component({
  selector: 'app-poker-game-results',
  templateUrl: './poker-game-results.component.html',
  styleUrls: ['./poker-game-results.component.scss']
})
export class PokerGameResultsComponent implements OnInit {

  @Input() results: PokerGameResults;

  constructor() { }

  ngOnInit(): void {
  }

}
