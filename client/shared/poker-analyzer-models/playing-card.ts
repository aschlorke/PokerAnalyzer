import { Suit } from "./enums/suit.enum";

export interface PlayingCard {
  readonly rank: string;
  readonly value: number;
  readonly suit: Suit;
}

