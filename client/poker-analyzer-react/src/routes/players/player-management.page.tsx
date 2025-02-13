import { Button, Stack } from "@mui/material";
import { useCallback } from "react";
import {
  useAddPlayerMutation,
  useGetPlayersQuery,
} from "../../api/games/player.api";

export const PlayerManagementPage = () => {
  const { currentData: players } = useGetPlayersQuery();
  const [addPlayer] = useAddPlayerMutation();

  const onClick = useCallback(() => {
    void addPlayer({ name: "aaron" });
  }, [addPlayer]);

  return (
    <>
      <Stack spacing={1} alignSelf="flex-end" flex="0 0 25%">
        <Button variant="contained" onClick={() => onClick()}>
          Add Player
        </Button>
      </Stack>

      {players !== undefined && (
        <>
          {players.map((p) => (
            <>{p.name}</>
          ))}
        </>
      )}
    </>
  );
};
