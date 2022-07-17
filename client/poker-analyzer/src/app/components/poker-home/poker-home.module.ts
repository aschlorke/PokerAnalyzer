import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { PokerGameModule } from '../poker-game/poker-game.module';
import { PokerHomeComponent } from './poker-home.component.container';
import { PokerHomeComponentUI } from './poker-home.component.presentation';

@NgModule({
  declarations: [
    PokerHomeComponent,
    PokerHomeComponentUI
  ],
  imports: [
    BrowserModule,
    PokerGameModule,
    FormsModule
  ],
  exports: [
    PokerHomeComponent
  ]
})
export class PokerHomeModule { }
