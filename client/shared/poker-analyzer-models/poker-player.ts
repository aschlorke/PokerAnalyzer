import { PlayingCard } from "./playing-card";
import { PlayerId } from "./types/Keys";

export interface PokerHand {
  playerId: PlayerId;
  cards: PlayingCard[];
}

export interface Player {
  playerId: PlayerId;
  name: string;
}
