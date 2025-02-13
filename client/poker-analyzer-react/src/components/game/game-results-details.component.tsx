import { Typography } from "@mui/material";
import { PokerGameResults } from "../../../../shared/poker-analyzer-models/poker-game-results";
import { EmptyGuid } from "../../../../shared/poker-analyzer-models/types/Guid";
import { useGetPlayerByIdQuery } from "../../api/games/player.api";

interface Props {
  results: PokerGameResults;
}

export const GameResultsDetails = ({ results }: Props) => {
  const { currentData: player, isLoading } = useGetPlayerByIdQuery(
    results.winner
  );
  const message =
    results.winner === EmptyGuid
      ? `The game was a draw; all players tied with ${results.winningHand}.`
      : `${player?.name ?? results.winner} wins with ${results.winningHand}!`;

  if (isLoading) return null;
  return <Typography>{message}</Typography>;
};
