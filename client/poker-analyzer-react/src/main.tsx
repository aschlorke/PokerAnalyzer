import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.tsx";
import { ApiProvider } from "@reduxjs/toolkit/query/react";
import { pokerAnalyzerApi } from "./api/poker-analyzer.api.ts";
import { ThemeProvider } from "@mui/material";
import { theme } from "./components/theme.component.tsx";

createRoot(document.getElementById("root") as HTMLElement).render(
  <StrictMode>
    <ApiProvider api={pokerAnalyzerApi}>
      <ThemeProvider theme={theme}>
        <App />
      </ThemeProvider>
    </ApiProvider>
  </StrictMode>
);
