import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PokerGameModule } from '../poker-game/poker-game.module';

import { PokerHomeComponent } from './poker-home.component';

@NgModule({
  declarations: [
    PokerHomeComponent,
  ],
  imports: [
    BrowserModule,
    PokerGameModule
  ],
  exports: [
    PokerHomeComponent
  ]
})
export class PokerHomeModule { }
