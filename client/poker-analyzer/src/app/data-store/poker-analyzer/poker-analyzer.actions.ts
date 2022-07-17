import { createAction, props } from "@ngrx/store";
import { PokerGame } from "../../models/poker-game";

export const SetNumberOfPlayers = createAction("[Poker Analyzer Action] Set Number of Players", props<{ numberOfPlayers: number }>());
export const SetCurrentGame = createAction("[Poker Analyzer Action] Set Current Game", props<{ id: number }>());
export const SetCurrentGameSuccess = createAction("[Poker Analyzer Action] Set Current Game Success", props<{ pokerGame: PokerGame }>());
export const CreateNewGame = createAction("[Poker Analyzer Action] Create New Game");
export const DeleteGame = createAction("[Poker Analyzer Action] Delete Game", props<{ id: number }>());
export const DeleteGameSuccess = createAction("[Poker Analyzer Action] Delete Game Success", props<{ id: number }>());
export const GetExistingIds = createAction("[Poker Analyzer Action] Get Existing Ids");
export const GetExistingIdsSuccess = createAction("[Poker Analyzer Action] Get Existing Ids Success", props<{ ids: number[] }>());
