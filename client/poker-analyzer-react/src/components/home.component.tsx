import { useCallback, useState } from "react";
import { useAddGameMutation, useGetGamesQuery } from "../api/games/games.api";
import { GameDetails } from "./game-details.component";
import {
  Box,
  Button,
  MenuItem,
  Stack,
  TextField,
  Typography,
} from "@mui/material";

const ValidNumberOfPlayers = [2, 3, 4, 5, 6, 7, 8, 9, 10] as const;

export const Home = () => {
  const [numberOfPlayers, setNumberOfPlayers] = useState<number>(
    ValidNumberOfPlayers[0]
  );

  const { currentData: games } = useGetGamesQuery();
  const [addGame] = useAddGameMutation();

  const onClick = useCallback(() => {
    void addGame(numberOfPlayers);
  }, [addGame, numberOfPlayers]);

  return (
    <Box sx={{ display: "flex", flexDirection: "column", width: "100%" }}>
      <Typography variant="h3">Poker Analyzer</Typography>
      <Stack
        spacing={1}
        sx={{
          alignSelf: "flex-end",
        }}
      >
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
      {games?.map((game) => (
        <GameDetails key={game.id} game={game} />
      ))}
    </Box>
  );
};
