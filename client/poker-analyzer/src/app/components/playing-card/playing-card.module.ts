import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PlayingCardComponent } from './playing-card.component';

@NgModule({
  declarations: [
    PlayingCardComponent
  ],
  imports: [
    BrowserModule,
  ],
  exports: [
    PlayingCardComponent
  ]
})
export class PlayingCardModule { }
