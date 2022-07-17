import { Component, Input, OnInit } from '@angular/core';
import { Suit } from 'src/app/models/enums/suit.enum';
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
    // console.log("ngOnInit Card.ts: " + this.playingCard.value + this.playingCard.suit);
  }

  getImage(): string {
    const suit = this.playingCard.suit;
    const suitName: string =
      suit === Suit.Clubs ? 'Clubs'
        : suit === Suit.Diamonds ? 'Diamonds'
          : suit === Suit.Hearts ? 'Hearts'
            : 'Spades';
    return `/assets/cards/${suitName}/${this.playingCard.rank.toLocaleLowerCase()}.png`;
  }
}
