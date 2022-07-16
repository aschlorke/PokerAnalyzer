import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PlayingCardListModule } from './playing-card-list/playing-card-list.module';
import { PlayingCardModule } from './playing-card/playing-card.module';

import { PokerGameModule } from './poker-game/poker-game.module';

@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    PlayingCardModule,
    PlayingCardListModule,
    PokerGameModule,
  ],
  exports: [
    PlayingCardModule,
    PlayingCardListModule,
    PokerGameModule,
  ]
})
export class ComponentsModule { }
