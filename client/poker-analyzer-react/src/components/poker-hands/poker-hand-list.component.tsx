import { Box } from "@mui/material";
import { PokerHand } from "../../../../shared/poker-analyzer-models/poker-player";
import { PokerHandDetails } from "./poker-hand-details.component";

interface Props {
  pokerHands: PokerHand[];
}

export const PokerHandList = ({ pokerHands }: Props) => {
  return (
    <Box
      style={{
        display: "flex",
        flexDirection: "row",
        flexWrap: "wrap",
        justifyContent: "space-between",
      }}
    >
      {pokerHands.map((p) => (
        <PokerHandDetails key={p.playerId} pokerHand={p} />
      ))}
    </Box>
  );
};
