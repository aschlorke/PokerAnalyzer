import { PokerHand } from "./poker-player";
import { PokerGameResults } from "./poker-game-results";

export interface PokerGame {
  pokerGameId: number;
  pokerHands: PokerHand[];
  results: PokerGameResults | null;
}
