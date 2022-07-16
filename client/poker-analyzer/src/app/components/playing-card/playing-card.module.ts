import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PlayingCardComponent } from './playing-card.component';

@NgModule({
  declarations: [
    PlayingCardComponent
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule
  ],
  exports: [
    PlayingCardComponent
  ]
})
export class PlayingCardModule { }
