import {
  Box,
  Toolbar,
  Typography,
  AppBar,
  List,
  ListItem,
} from "@mui/material";
import { NavLink } from "react-router";

const navItems = [
  { label: "Home", route: "/" },
  { label: "Games", route: "/games" },
  { label: "Players", route: "/players" },
] as const;

export const PokerAppBar = () => {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h3" component="div" sx={{ flexGrow: 1 }}>
            Poker Analyzer
          </Typography>
          <List sx={{ flexDirection: "row", display: "flex" }}>
            {navItems.map((item) => (
              <ListItem key={item.label}>
                <NavLink to={item.route}>
                  <Typography sx={{ color: "white" }} variant="button">
                    {item.label}
                  </Typography>
                </NavLink>
              </ListItem>
            ))}
          </List>{" "}
        </Toolbar>
      </AppBar>
    </Box>
  );
};
