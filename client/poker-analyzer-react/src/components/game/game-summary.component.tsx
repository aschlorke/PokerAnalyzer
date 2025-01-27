import { Divider, Stack, Typography } from "@mui/material";
import { PokerGame } from "../../../../shared/poker-analyzer-models/poker-game";
import { ReactNode } from "react";

interface Props {
  game: PokerGame;
  renderTitleComponent?: (title: string) => ReactNode;
}

export const GameSummary = ({ game, renderTitleComponent }: Props) => {
  const titleComponent = renderTitleComponent?.(
    `Game ID: ${game.pokerGameId.toString()}`
  ) ?? <Typography>Game ID: {game.pokerGameId}</Typography>;
  return (
    <Stack
      alignItems="center"
      divider={<Divider />}
      gap={1}
      display="flex"
      flexDirection="row"
    >
      {titleComponent}
      <Typography>{game.players.map((p) => p.name).join(", ")}</Typography>
      {game.results !== null && (
        <>
          <Typography>{game.results.winner} won the game!</Typography>
        </>
      )}
    </Stack>
  );
};
