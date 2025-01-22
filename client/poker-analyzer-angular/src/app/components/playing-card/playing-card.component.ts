import { Component, Input, OnInit } from '@angular/core';
import { PlayingCard } from '../../../../../shared/poker-analyzer-models/playing-card';
import { Suit } from '../../../../../shared/poker-analyzer-models/enums/suit.enum';

@Component({
  selector: 'app-playing-card',
  templateUrl: './playing-card.component.html',
  styleUrls: ['./playing-card.component.scss'],
})
export class PlayingCardComponent implements OnInit {
  @Input() public playingCard: PlayingCard | null = null;

  constructor() {}

  ngOnInit(): void {}

  getImage(): string {
    if (this.playingCard === null) return '';
    const suit = this.playingCard.suit;
    const suitName: string =
      suit === Suit.Clubs
        ? 'Clubs'
        : suit === Suit.Diamonds
        ? 'Diamonds'
        : suit === Suit.Hearts
        ? 'Hearts'
        : 'Spades';
    return `/assets/cards/${suitName}/${this.playingCard.rank.toLocaleLowerCase()}.png`;
  }
}
