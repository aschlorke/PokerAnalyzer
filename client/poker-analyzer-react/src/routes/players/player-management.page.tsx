import { Button, Stack } from "@mui/material";
import { useCallback } from "react";
import {
  useAddPlayerMutation,
  useDeletePlayerMutation,
  useGetPlayersQuery,
} from "../../api/games/player.api";

export const PlayerManagementPage = () => {
  const { currentData: players } = useGetPlayersQuery();
  const [addPlayer] = useAddPlayerMutation();
  const [deletePlayer] = useDeletePlayerMutation();

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
        // Players in general should be fleshed out a lot more
        // Customizable names/information, etc.
        <>
          {players.map((p) => (
            <Stack key={p.playerId} spacing={1} flexDirection="column">
              <>
                {p.name}{" "}
                <Button onClick={() => void deletePlayer(p.playerId)}>
                  Delete
                </Button>
              </>
            </Stack>
          ))}
        </>
      )}
    </>
  );
};
