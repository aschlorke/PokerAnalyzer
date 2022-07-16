import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PlayingCardListModule } from '../card-list/playing-card-list.module';

import { PokerGameComponent } from './poker-game.component.container';
import { PokerGameComponentUI } from './poker-game.component.presentation';

@NgModule({
  declarations: [
    PokerGameComponentUI,
    PokerGameComponent,
  ],
  imports: [
    BrowserModule,
    PlayingCardListModule
  ],
  exports: [
    PokerGameComponent
  ]
})
export class PokerGameModule { }
