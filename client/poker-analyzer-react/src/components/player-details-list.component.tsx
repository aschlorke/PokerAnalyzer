import { Player } from "../../../shared/poker-analyzer-models/player";
import { PlayerDetails } from "./player-details.component";

interface Props {
  players: Player[];
}

export const PlayerDetailsList = ({ players }: Props) => {
  return (
    <div
      style={{
        display: "flex",
        flexDirection: "row",
        flexWrap: "wrap",
        justifyContent: "space-between",
      }}
    >
      {players.map((p) => (
        <PlayerDetails key={p.name} player={p} />
      ))}
    </div>
  );
};
