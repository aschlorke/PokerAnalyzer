import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PokerGame } from '../../../../../poker-analyzer-models/poker-game';
import { AppState } from '../../app-state';
import {
  GetExistingIds,
  CreateNewGame,
  SetCurrentGame,
  DeleteGame,
  SetNumberOfPlayers,
} from '../../data-store/poker-analyzer/poker-analyzer.actions';
import {
  getExistingGameIds,
  getCurrentGame,
} from '../../data-store/poker-analyzer/poker-analyzer.reducer';

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
    </app-poker-home-ui>
  `,
})
export class PokerHomeComponent implements OnInit {
  gameIds$: Observable<number[]>;
  currentGame$: Observable<PokerGame | null>;

  constructor(private _store: Store<AppState>) {}

  ngOnInit(): void {
    this._store.dispatch(GetExistingIds());
    this.gameIds$ = this._store.select(getExistingGameIds);
    this.currentGame$ = this._store.select(getCurrentGame);
  }

  startNewGame(): void {
    this._store.dispatch(CreateNewGame());
  }

  selectGameId(event: number): void {
    this._store.dispatch(SetCurrentGame({ id: event }));
  }

  deleteGame(event: number): void {
    this._store.dispatch(DeleteGame({ id: event }));
  }

  updateNumPlayers(event: number): void {
    this._store.dispatch(SetNumberOfPlayers({ numberOfPlayers: event }));
  }
}
