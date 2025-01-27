import { Box } from "@mui/material";
import { PlayingCard } from "../../../../shared/poker-analyzer-models/playing-card";
import { PlayingCardView } from "./playing-card-view.component";

interface Props {
  cards: PlayingCard[];
}

export const PlayingCardList = ({ cards }: Props) => {
  return cards.map((c) => (
    <Box
      key={`${c.rank}${c.suit.toString()}`}
      style={{ display: "flex", flex: "1 1 0px", padding: "0.5rem" }}
    >
      <PlayingCardView card={c} />
    </Box>
  ));
};
