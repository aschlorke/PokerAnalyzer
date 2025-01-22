import { Player } from "../../../shared/poker-analyzer-models/player";
import { PlayingCardView } from "./playing-card-view.component";

interface Props {
  player: Player;
}

export const PlayerDetails = ({ player }: Props) => {
  return (
    <div
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
      <div
        style={{
          display: "flex",
          flexDirection: "row",
          padding: "1rem",
        }}
      >
        {player.cards.map((c) => (
          <div
            key={`${c.rank}${c.suit.toString()}`}
            style={{ display: "flex", flex: "1 1 0px", padding: "0.5rem" }}
          >
            <PlayingCardView card={c} />
          </div>
        ))}
      </div>
    </div>
  );
};
