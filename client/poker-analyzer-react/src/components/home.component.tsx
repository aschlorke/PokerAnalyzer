import { useCallback, useState } from "react";
import { useAddGameMutation, useGetGamesQuery } from "../api/games/games.api";
import { GameDetails } from "./game-details.component";

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
    <div style={{ display: "flex", flexDirection: "column" }}>
      <h1>Poker Analyzer</h1>
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          alignItems: "flex-end",
          flex: "0 0 25%",
        }}
      >
        <div style={{ display: "flex", padding: "1rem" }}>
          <button onClick={() => onClick()}>Add new game</button>
        </div>
        <div
          style={{
            display: "flex",
            flexDirection: "row",
            alignItems: "center",
          }}
        >
          <label style={{ paddingRight: "1rem" }} htmlFor="number-of-players">
            Number of Players
          </label>
          <select
            id="number-of-players"
            onChange={(e) => setNumberOfPlayers(+e.target.value)}
          >
            {ValidNumberOfPlayers.map((i) => (
              <option key={i} value={i}>
                {i}
              </option>
            ))}
          </select>
        </div>
      </div>
      {games?.map((game) => (
        <GameDetails key={game.id} game={game} />
      ))}
    </div>
  );
};
