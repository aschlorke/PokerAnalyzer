import { Player } from "./player";

export class PokerGame {
    public readonly id: number;
    public readonly players: Player[];        

    public constructor (id: number, players: Player[])
    {
        this.id = id;
        this.players = players;
    }

    public static fromJson(json: string): PokerGame {
        return JSON.parse(json);
    }
}
