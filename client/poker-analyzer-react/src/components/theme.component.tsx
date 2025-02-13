import { createTheme } from "@mui/material";

export const theme = createTheme({
  palette: {},
  components: {
    MuiTextField: {
      styleOverrides: {
        root: {
          backgroundColor: "#f0f0f0",
        },
      },
    },
    MuiInputBase: {
      styleOverrides: {
        root: {
          backgroundColor: "#f0f0f0",
        },
      },
    },
  },
});
