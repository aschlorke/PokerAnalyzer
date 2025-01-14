import { Player } from "./player";

export class PokerGameResults {
    public readonly winner: string;
    public readonly winningHand: string;

    public constructor(winner: string, winningHand: string) {
        this.winner = winner;
        this.winningHand = winningHand;
    }
}
