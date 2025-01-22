import { PokerGame } from "../../../shared/poker-analyzer-models/poker-game";
import { GameResultsDetails } from "./game-results-details.component";
import { PlayerDetailsList } from "./player-details-list.component";

interface Props {
  game: PokerGame;
}

export const GameDetails = ({ game }: Props) => {
  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        padding: "1rem",
      }}
    >
      <div
        style={{
          display: "flex",
          flexDirection: "column",
        }}
      >
        <div style={{ display: "flex", fontWeight: 500 }}>
          Game ID: {game.id}
        </div>
        <div
          style={{
            display: "flex",
            flexDirection: "row",
          }}
        >
          <div style={{ paddingRight: "0.5rem" }}>Results: </div>
          <GameResultsDetails results={game.results} />
        </div>
      </div>
      <div
        style={{
          display: "flex",
          flexDirection: "row",
          padding: "1rem",
          paddingTop: 0,
        }}
      >
        <PlayerDetailsList players={game.players} />
      </div>
    </div>
  );
};
