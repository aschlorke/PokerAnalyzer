import { Box } from "@mui/material";
import { GameResultsDetails } from "../../components/game/game-results-details.component";
import { PlayerDetailsList } from "../../components/player/player-details-list.component";
import { useParams } from "react-router";
import { useGetGameByIdQuery } from "../../api/games/games.api";
import { skipToken } from "@reduxjs/toolkit/query";

export const GameDetails = () => {
  const { gameId } = useParams<{ gameId: string }>();
  const parsedId = gameId !== undefined ? parseInt(gameId) : undefined;
  const { currentData: game } = useGetGameByIdQuery(parsedId ?? skipToken);

  if (game === undefined) return null;

  return (
    <Box
      style={{
        display: "flex",
        flexDirection: "column",
        padding: "1rem",
      }}
    >
      <Box
        style={{
          display: "flex",
          flexDirection: "column",
        }}
      >
        <Box style={{ display: "flex", fontWeight: 500 }}>
          Game ID: {game.pokerGameId}
        </Box>
        <Box
          style={{
            display: "flex",
            flexDirection: "row",
          }}
        >
          <Box style={{ paddingRight: "0.5rem" }}>Results: </Box>
          {game.results !== null && (
            <GameResultsDetails results={game.results} />
          )}
        </Box>
      </Box>
      <Box
        style={{
          display: "flex",
          flexDirection: "row",
          padding: "1rem",
          paddingTop: 0,
        }}
      >
        <PlayerDetailsList players={game.players} />
      </Box>
    </Box>
  );
};
