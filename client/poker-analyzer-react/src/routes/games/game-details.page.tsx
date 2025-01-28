import { useParams } from "react-router";
import { useGetGameByIdQuery } from "../../api/games/games.api";
import { skipToken } from "@reduxjs/toolkit/query";
import { GameDetails } from "../../components/game/game-details.component";

export const GameDetailsPage = () => {
  const { gameId } = useParams<{ gameId: string }>();
  const parsedId = gameId !== undefined ? parseInt(gameId) : undefined;
  const { currentData: game } = useGetGameByIdQuery(parsedId ?? skipToken);

  if (game === undefined) return null;
  return <GameDetails game={game} />;
};
