import { Box } from "@mui/material";
import { PokerGame } from "../../../../shared/poker-analyzer-models/poker-game";
import { PokerHandList } from "../poker-hands/poker-hand-list.component";
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
        <PokerHandList pokerHands={game.pokerHands} />
      </Box>
    </Box>
  );
};
