import { Card } from "./card";

export class Player {
    private readonly name: string;
    private readonly hand: Card[];

    public constructor (name: string, hand: Card[])
    {
        this.name = name;
        this.hand = hand;
    }
}

