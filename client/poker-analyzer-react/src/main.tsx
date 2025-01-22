import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.tsx";
import { ApiProvider } from "@reduxjs/toolkit/query/react";
import { pokerAnalyzerApi } from "./api/poker-analyzer.api.ts";

createRoot(document.getElementById("root") as HTMLElement).render(
  <StrictMode>
    <ApiProvider api={pokerAnalyzerApi}>
      <App />
    </ApiProvider>
  </StrictMode>
);
