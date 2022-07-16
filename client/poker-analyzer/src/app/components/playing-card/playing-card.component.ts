import { Component, Input, OnInit } from '@angular/core';
import { PlayingCard } from 'src/app/models/playing-card';

@Component({
  selector: 'app-playing-card',
  templateUrl: './playing-card.component.html',
  styleUrls: ['./playing-card.component.scss']
})
export class PlayingCardComponent implements OnInit {

  @Input() public playingCard: PlayingCard = null;

  constructor() { }

  ngOnInit(): void {
    console.log("ngOnInit Card.ts: " + this.playingCard.value + this.playingCard.suit);
  }

}
