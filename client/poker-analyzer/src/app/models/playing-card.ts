import { Suit } from "./enums/suit.enum";

export class PlayingCard {
    public readonly rank: string;
    public readonly value: number;
    public readonly suit: Suit;

    public constructor(rank: string, value: number, suit: Suit) {
        this.rank = rank;
        this.value = value;
        this.suit = suit;
    }

    public toString(): string {
        return `${this.rank}-${this.suit}`;
    }
}