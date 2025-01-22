import { PokerGameResults } from "../../../shared/poker-analyzer-models/poker-game-results";

interface Props {
  results: PokerGameResults;
}

export const GameResultsDetails = ({ results }: Props) => {
  return (
    <div>
      {results.winner} wins with {results.winningHand}
    </div>
  );
};
