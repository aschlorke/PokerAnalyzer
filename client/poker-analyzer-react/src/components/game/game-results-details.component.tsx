import { Typography } from "@mui/material";
import { PokerGameResults } from "../../../../shared/poker-analyzer-models/poker-game-results";

interface Props {
  results: PokerGameResults;
}

export const GameResultsDetails = ({ results }: Props) => {
  const message =
    results.winner === "Draw"
      ? `The game was a draw; all players tied with ${results.winningHand}.`
      : `${results.winner} wins with ${results.winningHand}!`;

  return <Typography>{message}</Typography>;
};
