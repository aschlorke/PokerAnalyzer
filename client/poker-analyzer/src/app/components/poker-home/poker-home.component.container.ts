import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from 'src/app/app-state';
import { CreateNewGame, DeleteGame, GetExistingIds, SetCurrentGame, SetNumberOfPlayers } from 'src/app/data-store/poker-analyzer/poker-analyzer.actions';
import { getCurrentGame, getExistingGameIds } from 'src/app/data-store/poker-analyzer/poker-analyzer.reducer';
import { PokerGame } from 'src/app/models/poker-game';

@Component({
  selector: 'app-poker-home',
  template: `
        <app-poker-home-ui
          [existingGameIds]="gameIds$ | async"
          [currentGame]="currentGame$ | async"
          (onStartNewGame)="startNewGame()"
          (onSelectGameId)="selectGameId($event)"
          (onDeleteGame)="deleteGame($event)"
          (onUpdateNumPlayers)="updateNumPlayers($event)"
        >    
    `,
})
export class PokerHomeComponent implements OnInit {

  gameIds$: Observable<number[]>;
  currentGame$: Observable<PokerGame>;

  constructor(
    private _store: Store<AppState>,
  ) { }

  ngOnInit(): void {
    this._store.dispatch(GetExistingIds())
    this.gameIds$ = this._store.select(getExistingGameIds);
    this.currentGame$ = this._store.select(getCurrentGame);
  }

  startNewGame(): void {
    this._store.dispatch(CreateNewGame());
  }

  selectGameId(event: number): void {
    this._store.dispatch(SetCurrentGame({id: event}));
  }

  deleteGame(event: number): void {
    this._store.dispatch(DeleteGame({id: event}));
  }

  updateNumPlayers(event: number): void {
    this._store.dispatch(SetNumberOfPlayers({numberOfPlayers: event}));
  }

}
