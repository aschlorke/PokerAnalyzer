import { PlayerId } from "../../../../shared/poker-analyzer-models/types/Keys";

export type AddGameForPlayersRequest = {
  playerIds: PlayerId[];
};
