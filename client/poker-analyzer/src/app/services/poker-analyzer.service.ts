import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PokerGame } from '../models/poker-game';

const controllerName: string = 'PokerAnalyzer';

@Injectable({
  providedIn: 'root'
})
export class PokerAnalyzerService {

  constructor(private _http: HttpClient) { }

  getNewPokerGame(): Observable<any> {
    return this._http.post<number>(`${environment.apiEndpoint}/${controllerName}/GetNewGame`, { numberOfPlayers: 3 });
  }
}
