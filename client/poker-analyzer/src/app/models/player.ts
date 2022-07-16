import { PlayingCard } from "./playing-card";

export class Player {
    public readonly name: string;
    public readonly hand: PlayingCard[];

    public constructor (name: string, hand: PlayingCard[])
    {
        this.name = name;
        this.hand = hand;
    }
}

