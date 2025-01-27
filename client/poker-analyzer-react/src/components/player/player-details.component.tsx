import { Box } from "@mui/material";
import { Player } from "../../../../shared/poker-analyzer-models/player";
import { PlayingCardList } from "../playing-card/playing-card-list.component";

interface Props {
  player: Player;
}

export const PlayerDetails = ({ player }: Props) => {
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
      {player.name}
      <Box
        style={{
          display: "flex",
          flexDirection: "row",
          padding: "1rem",
        }}
      >
        <PlayingCardList cards={player.cards} />
      </Box>
    </Box>
  );
};
