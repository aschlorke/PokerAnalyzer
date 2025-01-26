import { Suit } from "./enums/suit.enum";

export interface PlayingCard {
  rank: string;
  value: number;
  suit: Suit;
}
