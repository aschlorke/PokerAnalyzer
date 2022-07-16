import { Suit } from "./enums/suit.enum";

export class PlayingCard {
    public readonly value: number;
    public readonly suit: Suit;

    public constructor(value: number, suit: Suit) {
        this.value = value;
        this.suit = suit;
    }

    public toString(): string {
        return `${this.value}${this.suit}`;
    }
}