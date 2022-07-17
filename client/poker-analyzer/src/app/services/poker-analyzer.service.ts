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

  getNewPokerGame(numberOfPlayers: number): Observable<PokerGame> {
    return this._http.post<PokerGame>(`${environment.apiEndpoint}/${controllerName}/GetNewGame`, { numberOfPlayers: numberOfPlayers });
  }

  getExistingPokerGame(id: number): Observable<PokerGame> {
    return this._http.get<PokerGame>(`${environment.apiEndpoint}/${controllerName}/${id}`);
  }
  getExistingPokerGameIds(): Observable<number[]> {
    return this._http.get<number[]>(`${environment.apiEndpoint}/${controllerName}/GetExistingIds`);
  }

  deleteGame(id: number): Observable<boolean> {
    return this._http.delete<boolean>(`${environment.apiEndpoint}/${controllerName}/${id}`);
  }
}
