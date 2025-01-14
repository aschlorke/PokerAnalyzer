import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PlayingCardListModule } from '../playing-card-list/playing-card-list.module';
import { PokerGameResultsModule } from '../poker-game-results/poker-game-results.module';

import { PokerGameComponent } from './poker-game.component';

@NgModule({
  declarations: [
    PokerGameComponent,
  ],
  imports: [
    BrowserModule,
    PlayingCardListModule,
    PokerGameResultsModule
  ],
  exports: [
    PokerGameComponent
  ]
})
export class PokerGameModule { }
