import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PokerGame } from '../models/poker-game';

@Injectable({
  providedIn: 'root'
})
export class PokerAnalyzerService {

  constructor(private _http: HttpClient) { }

  getNewPokerGame(): Observable<PokerGame> {
    return this._http.get<PokerGame>(environment.apiEndpoint + 'GetNewGame');
  }
}
