import { configureStore } from "@reduxjs/toolkit";
import { pokerAnalyzerApi } from "../api/poker-analyzer.api";

export const store = configureStore({
  reducer: {
    [pokerAnalyzerApi.reducerPath]: pokerAnalyzerApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(pokerAnalyzerApi.middleware),
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
