import {
  Button,
  Checkbox,
  FormControl,
  InputLabel,
  ListItemText,
  MenuItem,
  OutlinedInput,
  Select,
  SelectChangeEvent,
  Stack,
} from "@mui/material";
import {
  useAddGameMutation,
  useGetGamesQuery,
} from "../../api/games/games.api";
import { useState, useCallback } from "react";
import { GameList } from "../../components/game/game-list.component";
import { useGetPlayersQuery } from "../../api/games/player.api";
import { PlayerId } from "../../../../shared/poker-analyzer-models/types/Keys";

export const GameManagementPage = () => {
  const [selectedPlayers, setSelectedPlayers] = useState<PlayerId[]>([]);

  const { currentData: players } = useGetPlayersQuery();

  const { currentData: games } = useGetGamesQuery();

  const [addGame] = useAddGameMutation();

  const onClick = useCallback(() => {
    void addGame({ playerIds: selectedPlayers });
  }, [addGame, selectedPlayers]);

  const handleChange = (event: SelectChangeEvent<PlayerId[]>) => {
    if (!Array.isArray(event.target.value)) return;
    setSelectedPlayers(event.target.value);
  };

  return (
    <>
      <Stack spacing={1} alignSelf="flex-end" flex="0 0 25%">
        <Button variant="contained" onClick={() => onClick()}>
          Add new game
        </Button>
        <FormControl sx={{ m: 1, width: 300 }}>
          <InputLabel id="player-select-label">Players</InputLabel>
          <Select
            labelId="player-select-label"
            id="player-select"
            multiple
            value={selectedPlayers}
            onChange={handleChange}
            input={<OutlinedInput label="Tag" />}
            renderValue={(selected) => selected.join(", ")}
          >
            {players?.map((player) => (
              <MenuItem key={player.playerId} value={player.playerId}>
                <Checkbox checked={selectedPlayers.includes(player.playerId)} />
                <ListItemText primary={player.name} />
              </MenuItem>
            ))}
          </Select>
        </FormControl>
      </Stack>

      {games !== undefined && <GameList games={games} />}
    </>
  );
};
