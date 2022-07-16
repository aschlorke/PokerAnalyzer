import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { PlayingCardListModule } from './playing-card-list/playing-card-list.module';
import { PlayingCardModule } from './playing-card/playing-card.module';
import { PokerGameModule } from './poker-game/poker-game.module';
import { PokerGameResultsModule } from './poker-game-results/poker-game-results.module';

@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    PlayingCardModule,
    PlayingCardListModule,
    PokerGameModule,
    PokerGameResultsModule,
  ],
  exports: [
    PlayingCardModule,
    PlayingCardListModule,
    PokerGameModule,
    PokerGameResultsModule,
  ]
})
export class ComponentsModule { }
