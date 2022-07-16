import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { PokerGameComponentUI } from './poker-game.component.presentation';

@NgModule({
  declarations: [
    PokerGameComponentUI
  ],
  imports: [
    BrowserModule
  ],
  exports: [
    CardComponent,
    CardListComponent
  ]
})
export class ComponentsModule { }
