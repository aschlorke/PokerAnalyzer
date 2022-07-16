import { PlayingCard } from "./playing-card";

export class Player {
    public readonly name: string;
    public readonly cards: PlayingCard[];

    public constructor(name: string, cards: PlayingCard[]) {
        this.name = name;
        this.cards = cards;
    }
}

