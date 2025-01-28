import { Stack } from "@mui/material";
import { NavLink } from "react-router";
import { PokerGame } from "../../../../shared/poker-analyzer-models/poker-game";
import { GameSummary } from "./game-summary.component";

interface Props {
  games: PokerGame[];
}

export const GameList = ({ games }: Props) => {
  return (
    <Stack spacing={1}>
      {games.map((game) => (
        <GameSummary
          key={game.pokerGameId}
          game={game}
          renderTitleComponent={(title) => (
            <NavLink
              style={{ width: "fit-content" }}
              to={game.pokerGameId.toString()}
            >
              {title}
            </NavLink>
          )}
        />
      ))}
    </Stack>
  );
};
