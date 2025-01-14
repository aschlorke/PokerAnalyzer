import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { PokerGameResultsComponent } from './poker-game-results.component';

@NgModule({
  declarations: [
    PokerGameResultsComponent,
  ],
  imports: [
    BrowserModule,
  ],
  exports: [
    PokerGameResultsComponent
  ]
})
export class PokerGameResultsModule { }
