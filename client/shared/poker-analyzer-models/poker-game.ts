import { Player } from "./player";
import { PokerGameResults } from "./poker-game-results";

export interface PokerGame {
  pokerGameId: number;
  players: Player[];
  results: PokerGameResults;
}
