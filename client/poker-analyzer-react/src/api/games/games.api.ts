import { PokerGame } from "../../../../shared/poker-analyzer-models/poker-game";
import { pokerAnalyzerApi, TagTypes } from "../poker-analyzer.api";
import { Method } from "../util/httpMethods.enum";
import { providesList } from "../util/providesList.util";

export const gamesApi = pokerAnalyzerApi.injectEndpoints({
  endpoints: (builder) => ({
    getGameById: builder.query<PokerGame, number>({
      query: (id) => ({ url: `/poker-analyzer/${id.toString()}` }),
      providesTags: (result) =>
        result === undefined
          ? []
          : [{ type: TagTypes.games, id: result.pokerGameId }],
    }),
    getGames: builder.query<PokerGame[], void>({
      query: () => ({ url: "/poker-analyzer/" }),
      providesTags: (result) =>
        providesList(result, (r) => r.pokerGameId, TagTypes.games),
    }),
    addGame: builder.mutation<PokerGame, number>({
      query: (numberOfPlayers) => ({
        url: "/poker-analyzer",
        method: Method.post,
        data: { numberOfPlayers },
      }),
      invalidatesTags: (result) =>
        providesList(
          result === undefined ? result : [result],
          (r) => r.pokerGameId,
          TagTypes.games
        ),
    }),
    deleteGame: builder.mutation<void, number>({
      query: (id) => ({ url: `/poker-analyzer/${id.toString()}` }),
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
