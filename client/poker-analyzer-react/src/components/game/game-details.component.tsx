import { Box } from "@mui/material";
import { PokerGame } from "../../../../shared/poker-analyzer-models/poker-game";
import { PlayerDetailsList } from "../player/player-details-list.component";
import { GameResultsDetails } from "./game-results-details.component";

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
          {game.results !== null && (
            <GameResultsDetails results={game.results} />
          )}
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
