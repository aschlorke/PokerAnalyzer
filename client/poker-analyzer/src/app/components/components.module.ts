import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CardComponent } from './card/card.component';
import { CardListComponent } from './card-list/card-list.component';
import { PokerGameComponentUI } from './poker-game/poker-game.component.presentation';

@NgModule({
  declarations: [
    CardComponent,
    CardListComponent,
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
