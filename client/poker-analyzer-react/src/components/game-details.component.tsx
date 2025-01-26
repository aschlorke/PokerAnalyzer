import { Box } from "@mui/material";
import { PokerGame } from "../../../shared/poker-analyzer-models/poker-game";
import { GameResultsDetails } from "./game-results-details.component";
import { PlayerDetailsList } from "./player-details-list.component";

interface Props {
  game: PokerGame;
}

export const GameDetails = ({ game }: Props) => {
  return (
    <Box
      style={{
        display: "flex",
        flexDirection: "column",
        padding: "1rem",
      }}
    >
      <Box
        style={{
          display: "flex",
          flexDirection: "column",
        }}
      >
        <Box style={{ display: "flex", fontWeight: 500 }}>
          Game ID: {game.pokerGameId}
        </Box>
        <Box
          style={{
            display: "flex",
            flexDirection: "row",
          }}
        >
          <Box style={{ paddingRight: "0.5rem" }}>Results: </Box>
          <GameResultsDetails results={game.results} />
        </Box>
      </Box>
      <Box
        style={{
          display: "flex",
          flexDirection: "row",
          padding: "1rem",
          paddingTop: 0,
        }}
      >
        <PlayerDetailsList players={game.players} />
      </Box>
    </Box>
  );
};
