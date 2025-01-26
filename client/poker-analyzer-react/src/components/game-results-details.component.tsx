import { Box } from "@mui/material";
import { PokerGameResults } from "../../../shared/poker-analyzer-models/poker-game-results";

interface Props {
  results: PokerGameResults;
}

export const GameResultsDetails = ({ results }: Props) => {
  return (
    <Box>
      {results.winner} wins with {results.winningHand}
    </Box>
  );
};
