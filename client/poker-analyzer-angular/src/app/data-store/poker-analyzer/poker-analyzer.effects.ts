import { Injectable } from "@angular/core";
import * as pokerAnalyzerActions from "./poker-analyzer.actions";
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { Store } from "@ngrx/store";
import { take, withLatestFrom } from "rxjs";
import { getCurrentNumberOfPlayers, getExistingGameIds } from "./poker-analyzer.reducer";
import { map } from "rxjs";
import { AppState } from "src/app/app-state";
import { PokerAnalyzerService } from "src/app/services/poker-analyzer.service";


@Injectable()
export class PokerAnalyzerEffects {
    constructor(
        private _actions$: Actions ,
        private _store: Store<AppState>,
        private _analyzerService: PokerAnalyzerService
    ) {
    }

    createNewGame$ = createEffect(
        () => 
            this._actions$.pipe(
                ofType(pokerAnalyzerActions.CreateNewGame),
                withLatestFrom(this._store.select(getCurrentNumberOfPlayers)),
                map(([action, numPlayers]) => {
                    return this._analyzerService.getNewPokerGame(numPlayers)
                        .pipe(take(1))
                        .subscribe(pokerGame => {
                            this._store.dispatch(pokerAnalyzerActions.SetCurrentGameSuccess({pokerGame}));
                            // TODO: just re-fetching the ids is a pretty poor solution
                            this._store.dispatch(pokerAnalyzerActions.GetExistingIds());
                        });
                })
            ), {dispatch: false}
    );

    getExistingGame$ = createEffect(
        () => this._actions$.pipe(
            ofType(pokerAnalyzerActions.SetCurrentGame),
            map(action => {
                return this._analyzerService.getExistingPokerGame(action.id)
                    .pipe(take(1))
                    .subscribe(pokerGame => this._store.dispatch(pokerAnalyzerActions.SetCurrentGameSuccess({pokerGame})));
            })
        ), {dispatch: false}
    );

    getExistingIds$ = createEffect(
        () => this._actions$.pipe(
            ofType(pokerAnalyzerActions.GetExistingIds),
            map(action => {
                return this._analyzerService.getExistingPokerGameIds()
                    .pipe(take(1))
                    .subscribe(ids => this._store.dispatch(pokerAnalyzerActions.GetExistingIdsSuccess({ids})));;
            })
        ), {dispatch: false}
    );

    deleteGame$ = createEffect(
        () => this._actions$.pipe(
            ofType(pokerAnalyzerActions.DeleteGame),
            withLatestFrom(this._store.select(getExistingGameIds)),
            map(([action, ids]) => {
                return this._analyzerService.deleteGame(action.id)
                    .pipe(
                        take(1),
                        map((success) => {
                            if(success) {
                                this._store.dispatch(pokerAnalyzerActions.DeleteGameSuccess({id: action.id}));
                                // TODO: This is a hacky way to clear out the game when the last game was deleted,
                                // or to select a different game when one is available
                                const differentIds = ids.filter(id => id !== action.id);
                                if(!differentIds.length) {
                                    this._store.dispatch(pokerAnalyzerActions.SetCurrentGameSuccess(null));
                                } else {
                                    this._store.dispatch(pokerAnalyzerActions.SetCurrentGame({id: differentIds[0]}));
                                }
                            }
                        }
                    )).subscribe();
            })
        ), {dispatch: false}
    );
}