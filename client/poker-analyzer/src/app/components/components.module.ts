import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { PlayingCardListModule } from './playing-card-list/playing-card-list.module';
import { PlayingCardModule } from './playing-card/playing-card.module';
import { PokerGameModule } from './poker-game/poker-game.module';
import { PokerGameResultsModule } from './poker-game-results/poker-game-results.module';
import { PokerHomeModule } from './poker-home/poker-home.module';

@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    PlayingCardModule,
    PlayingCardListModule,
    PokerGameModule,
    PokerGameResultsModule,
    PokerHomeModule,
  ],
  exports: [
    PlayingCardModule,
    PlayingCardListModule,
    PokerGameModule,
    PokerGameResultsModule,
    PokerHomeModule,
  ]
})
export class ComponentsModule { }
