import { Suit } from "../../../shared/poker-analyzer-models/enums/suit.enum";
import { PlayingCard } from "../../../shared/poker-analyzer-models/playing-card";

export const getImagePath = (playingCard: PlayingCard) => {
  const suitName: string = Suit[playingCard.suit];
  return `/src/assets/cards/${suitName}/${playingCard.rank.toLocaleLowerCase()}.png`;
};
