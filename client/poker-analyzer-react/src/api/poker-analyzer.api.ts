import { createApi } from "@reduxjs/toolkit/query/react";
import { axiosBaseQuery } from "./util/axiosBaseQuery.util";

export const TagTypes = {
  games: "games",
  //   players: "players",
} as const;

export const pokerAnalyzerApi = createApi({
  reducerPath: "pokerAnalyzerApi",
  baseQuery: axiosBaseQuery({
    baseUrl: import.meta.env.VITE_BASE_API_URL,
  }),
  tagTypes: Object.values(TagTypes),
  endpoints: () => ({}), // to be injected
});
