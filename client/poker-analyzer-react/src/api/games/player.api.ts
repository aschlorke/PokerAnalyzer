import { Player } from "../../../../shared/poker-analyzer-models/poker-player";
import { PlayerId } from "../../../../shared/poker-analyzer-models/types/Keys";
import { pokerAnalyzerApi, TagTypes } from "../poker-analyzer.api";
import { AddPlayerRequest } from "../requests/players.requests";
import { Method } from "../util/httpMethods.enum";
import { providesList } from "../util/providesList.util";

const route = "poker-players";

export const playerApi = pokerAnalyzerApi.injectEndpoints({
  endpoints: (builder) => ({
    getPlayers: builder.query<Player[], void>({
      query: () => ({ url: `/${route}` }),
      providesTags: (result) =>
        providesList(result, (r) => r.playerId, TagTypes.players),
    }),
    getPlayerById: builder.query<Player, PlayerId>({
      query: (playerId) => ({ url: `/${route}/${playerId}` }),
      providesTags: (result) =>
        result ? [{ type: TagTypes.players, id: result.playerId }] : [],
    }),
    getPlayersByGameId: builder.query<Player[], number>({
      query: (id) => ({ url: `/${route}/games/${id.toString()}` }),
      providesTags: (result) =>
        providesList(result, (r) => r.playerId, TagTypes.players),
    }),
    addPlayer: builder.mutation<Player, AddPlayerRequest>({
      query: (addPlayerRequest) => ({
        url: `/${route}`,
        method: Method.post,
        data: addPlayerRequest,
      }),
      invalidatesTags: (result) =>
        providesList(
          result === undefined ? result : [result],
          (r) => r.playerId,
          TagTypes.players
        ),
    }),
    deletePlayer: builder.mutation<void, PlayerId>({
      query: (id) => ({ url: `/${route}/${id.toString()}` }),
      invalidatesTags: (_result, _error, id) => [
        { type: TagTypes.players, id: id },
      ],
    }),
  }),
  overrideExisting: "throw",
});

export const {
  useGetPlayersQuery,
  useGetPlayerByIdQuery,
  useGetPlayersByGameIdQuery,
  useAddPlayerMutation,
  useDeletePlayerMutation,
} = playerApi;
