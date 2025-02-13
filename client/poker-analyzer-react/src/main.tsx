import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import "./App.css";
import { ApiProvider } from "@reduxjs/toolkit/query/react";
import { pokerAnalyzerApi } from "./api/poker-analyzer.api.ts";
import { ThemeProvider } from "@mui/material";
import { theme } from "./components/theme.component.tsx";
import { createBrowserRouter, RouterProvider } from "react-router";
import { Root } from "./routes/root.tsx";
import ErrorPage from "./components/error-boundary.component.tsx";
import { GameManagementPage } from "./routes/games/game-management.page.tsx";
import { GameDetailsPage } from "./routes/games/game-details.page.tsx";
import { PlayerManagementPage } from "./routes/players/player-management.page.tsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: "games/",
        element: <GameManagementPage />,
        errorElement: <ErrorPage />,
      },
      {
        path: "games/:gameId",
        element: <GameDetailsPage />,
        errorElement: <ErrorPage />,
      },
      {
        path: "players/",
        element: <PlayerManagementPage />,
        errorElement: <ErrorPage />,
      },
    ],
  },
]);

createRoot(document.getElementById("root") as HTMLElement).render(
  <StrictMode>
    <ApiProvider api={pokerAnalyzerApi}>
      <ThemeProvider theme={theme}>
        <RouterProvider router={router} />
      </ThemeProvider>
    </ApiProvider>
  </StrictMode>
);
