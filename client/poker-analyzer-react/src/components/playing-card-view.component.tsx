import { PlayingCard } from "../../../shared/poker-analyzer-models/playing-card";
import { getImagePath } from "../utils/playing-card.utils";

interface Props {
  card: PlayingCard;
}

export const PlayingCardView = ({ card }: Props) => {
  return <img style={{ maxWidth: "100%" }} src={getImagePath(card)} />;
};
