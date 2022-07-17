import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { PokerGame } from 'src/app/models/poker-game';

@Component({
  selector: 'app-poker-home-ui',
  templateUrl: './poker-home.component.html',
  styleUrls: ['./poker-home.component.scss']
})
export class PokerHomeComponentUI implements OnInit {

  @Input() existingGameIds: number[] = [];

  _currentGame: PokerGame = null;
  @Input() set currentGame(val: PokerGame) {
    this._currentGame = val;
    if(val) {
      this.selectedGameId = val.id;
    }
  };
  get currentGame(): PokerGame  {
    return this._currentGame;
  };
  @Output() onStartNewGame = new EventEmitter<void>();
  @Output() onSelectGameId: EventEmitter<number> = new EventEmitter();
  @Output() onDeleteGame: EventEmitter<number> = new EventEmitter();
  @Output() onUpdateNumPlayers: EventEmitter<number> = new EventEmitter();

  public selectedGameId: number;
  public playerOptions: number[] = [2, 3, 4, 5, 6, 7, 8, 9, 10];

  constructor() { }

  ngOnInit(): void {
  }

  startNewGame(): void {
    this.onStartNewGame.emit();
  }

  selectExistingGame(event: number): void {
    this.onSelectGameId.emit(event);
  }

  deleteGame(): void {
    if(this.currentGame) {
      this.onDeleteGame.emit(this.currentGame.id);
    }
  }

  updateNumPlayers(event: any): void {
    this.onUpdateNumPlayers.emit(event.target.value);
  }

}
