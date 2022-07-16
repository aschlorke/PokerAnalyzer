import { Component, Input, OnInit } from '@angular/core';
import { PlayingCard } from 'src/app/models/playing-card';

@Component({
  selector: 'app-playing-card-list',
  templateUrl: './playing-card-list.component.html',
  styleUrls: ['./playing-card-list.component.scss']
})
export class PlayingCardListComponent implements OnInit {

  @Input() public playingCards: PlayingCard[] = [];
  constructor() { }

  ngOnInit(): void {
  }

}
