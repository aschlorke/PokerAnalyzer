import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PlayingCardModule } from '../playing-card/playing-card.module';
import { PlayingCardListComponent } from './playing-card-list.component';

@NgModule({
  declarations: [
    PlayingCardListComponent
  ],
  imports: [
    BrowserModule,
    PlayingCardModule
  ],
  exports: [
    PlayingCardListComponent
  ]
})
export class PlayingCardListModule { }
