import { createFeatureSelector, createReducer, createSelector, on, select } from "@ngrx/store";
import { AppState } from "src/app/app-state";
import { PokerGame } from "../../models/poker-game";
import * as pokerAnalyzerActions from './poker-analyzer.actions';

export const pokerAnalyzerStateKey = 'PokerAnalyzerState';

export interface PokerAnalyzerState {
    currentGame: PokerGame,
    currentNumberOfPlayers: number,
    existingGameIds: number[]
}

const initialPokerAnalyzerState: PokerAnalyzerState = {
    currentGame: null,
    currentNumberOfPlayers: 2,
    existingGameIds: []
};

export const pokerAnalyzerReducer = createReducer(
    initialPokerAnalyzerState,
    on(pokerAnalyzerActions.SetCurrentGameSuccess, (state, action) => {
        return {
            ...state,
            currentGame: action.pokerGame
        }
    }),
    on(pokerAnalyzerActions.SetNumberOfPlayers, (state, action) => {
        return {
            ...state,
            currentNumberOfPlayers: action.numberOfPlayers
        }
    }),
    on(pokerAnalyzerActions.GetExistingIdsSuccess, (state, action) => {
        return {
            ...state,
            existingGameIds: action.ids
        }
    }),
    on(pokerAnalyzerActions.DeleteGameSuccess, (state, action) => {
        const currentIds = [...state.existingGameIds].filter(id => id !== action.id);

        return {
            ...state,
            existingGameIds: currentIds
        }
    }),
)

export const selectPokerAnalyzerState = createFeatureSelector<AppState, PokerAnalyzerState>(pokerAnalyzerStateKey);
export const getCurrentNumberOfPlayers = createSelector(
    selectPokerAnalyzerState, 
    (pokerAnalyzerState: PokerAnalyzerState) => pokerAnalyzerState.currentNumberOfPlayers
);

export const getCurrentGame = createSelector(
    selectPokerAnalyzerState,
    (pokerAnalyzerState: PokerAnalyzerState) => pokerAnalyzerState.currentGame
);

export const getExistingGameIds = createSelector(
    selectPokerAnalyzerState,
    (pokerAnalyzerState: PokerAnalyzerState) => pokerAnalyzerState.existingGameIds
);