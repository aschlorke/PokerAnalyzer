import { Player } from "./player";
import { PokerGameResults } from "./poker-game-results";

export class PokerGame {
    public readonly id: number;
    public readonly players: Player[];
    public readonly results: PokerGameResults;

    public constructor(id: number, players: Player[], results: PokerGameResults) {
        this.id = id;
        this.players = players;
        this.results = results;
    }
}
