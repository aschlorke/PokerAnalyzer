import { Box } from "@mui/material";
import { PokerHand } from "../../../../shared/poker-analyzer-models/poker-player";
import { PlayingCardList } from "../playing-card/playing-card-list.component";
import { useGetPlayerByIdQuery } from "../../api/games/player.api";

interface Props {
  pokerHand: PokerHand;
}

export const PokerHandDetails = ({ pokerHand }: Props) => {
  const { currentData: player, isLoading } = useGetPlayerByIdQuery(
    pokerHand.playerId
  );

  if (isLoading) return null;
  return (
    <Box
      style={{
        alignItems: "center",
        display: "flex",
        flexDirection: "row",
        padding: "1rem",
        flex: "0 0 40%",
      }}
    >
      {" "}
      {player?.name}
      <Box
        style={{
          display: "flex",
          flexDirection: "row",
          padding: "1rem",
        }}
      >
        <PlayingCardList cards={pokerHand.cards} />
      </Box>
    </Box>
  );
};
