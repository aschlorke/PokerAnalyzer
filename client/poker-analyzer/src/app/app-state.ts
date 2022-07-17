import { ActionReducerMap } from '@ngrx/store'
import { PokerAnalyzerEffects } from './data-store/poker-analyzer/poker-analyzer.effects'
import * as fromPokerAnalyzer from './data-store/poker-analyzer/poker-analyzer.reducer'

export interface AppState {
    [fromPokerAnalyzer.pokerAnalyzerStateKey]: fromPokerAnalyzer.PokerAnalyzerState
}

export const reducers: ActionReducerMap<AppState> = {
    [fromPokerAnalyzer.pokerAnalyzerStateKey]: fromPokerAnalyzer.pokerAnalyzerReducer
}

export const effects = [
    PokerAnalyzerEffects
];