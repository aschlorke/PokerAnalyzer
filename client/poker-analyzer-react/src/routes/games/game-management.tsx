import { Button, MenuItem, Stack, TextField } from "@mui/material";
import { NavLink } from "react-router";
import {
  useAddGameMutation,
  useGetGamesQuery,
} from "../../api/games/games.api";
import { useState, useCallback } from "react";
import { GameSummary } from "../../components/game/game-summary.component";

const ValidNumberOfPlayers = [2, 3, 4, 5, 6, 7, 8, 9, 10] as const;

export const GameManagement = () => {
  const [numberOfPlayers, setNumberOfPlayers] = useState<number>(
    ValidNumberOfPlayers[0]
  );

  const { currentData: games } = useGetGamesQuery();
  const [addGame] = useAddGameMutation();

  const onClick = useCallback(() => {
    void addGame(numberOfPlayers);
  }, [addGame, numberOfPlayers]);

  return (
    <>
      <Stack spacing={1} alignSelf="flex-end" flex="0 0 25%">
        <Button variant="contained" onClick={() => onClick()}>
          Add new game
        </Button>
        <TextField
          select
          fullWidth
          label="Number of Players"
          variant="filled"
          value={numberOfPlayers}
          onChange={(e) => setNumberOfPlayers(+e.target.value)}
        >
          {ValidNumberOfPlayers.map((i) => (
            <MenuItem key={i} value={i}>
              {i}
            </MenuItem>
          ))}
        </TextField>
      </Stack>

      {games !== undefined && (
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
      )}
    </>
  );
};
