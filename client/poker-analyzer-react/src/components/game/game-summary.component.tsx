import { Divider, Stack, Typography } from "@mui/material";
import { PokerGame } from "../../../../shared/poker-analyzer-models/poker-game";
import { ReactNode } from "react";
import { useGetPlayersByGameIdQuery } from "../../api/games/player.api";

interface Props {
  game: PokerGame;
  renderTitleComponent?: (title: string) => ReactNode;
}

export const GameSummary = ({ game, renderTitleComponent }: Props) => {
  const { currentData: players, isLoading } = useGetPlayersByGameIdQuery(
    game.pokerGameId
  );

  if (isLoading) return null;

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
      <Typography>{players?.map((p) => p.name).join(", ")}</Typography>
      {game.results !== null && (
        <>
          <Typography>
            {players?.find((p) => p.playerId === game.results?.winner)?.name}{" "}
            won the game!
          </Typography>
        </>
      )}
    </Stack>
  );
};
