import { PokerGame } from "../../../../shared/poker-analyzer-models/poker-game";
import { pokerAnalyzerApi, TagTypes } from "../poker-analyzer.api";
import { AddGameForPlayersRequest } from "../requests/games.requests";
import { Method } from "../util/httpMethods.enum";
import { providesList } from "../util/providesList.util";

const route = "poker-games";

export const gamesApi = pokerAnalyzerApi.injectEndpoints({
  endpoints: (builder) => ({
    getGameById: builder.query<PokerGame, number>({
      query: (id) => ({ url: `/${route}/${id.toString()}` }),
      providesTags: (result) =>
        result === undefined
          ? []
          : [{ type: TagTypes.games, id: result.pokerGameId }],
    }),
    getGames: builder.query<PokerGame[], void>({
      query: () => ({ url: `/${route}/` }),
      providesTags: (result) =>
        providesList(result, (r) => r.pokerGameId, TagTypes.games),
    }),
    addGame: builder.mutation<PokerGame, AddGameForPlayersRequest>({
      query: (request) => ({
        url: `/${route}/with-players`,
        method: Method.post,
        data: request,
      }),
      invalidatesTags: (result) =>
        providesList(
          result === undefined ? result : [result],
          (r) => r.pokerGameId,
          TagTypes.games
        ),
    }),
    deleteGame: builder.mutation<void, number>({
      query: (id) => ({ url: `/${route}/${id.toString()}` }),
      invalidatesTags: (_result, _error, id) => [
        { type: TagTypes.games, id: id },
      ],
    }),
  }),
  overrideExisting: "throw",
});

export const {
  useGetGameByIdQuery,
  useGetGamesQuery,
  useAddGameMutation,
  useDeleteGameMutation,
} = gamesApi;
