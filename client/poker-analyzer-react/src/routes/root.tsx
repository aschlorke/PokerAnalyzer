import { Box } from "@mui/material";
import { Outlet } from "react-router";
import { PokerAppBar } from "../components/app-bar.component";

export const Root = () => {
  return (
    <>
      <PokerAppBar />
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          padding: 1,
        }}
      >
        <Outlet />
      </Box>
    </>
  );
};
