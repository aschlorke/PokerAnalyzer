import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PokerGame } from '../models/poker-game';

const controllerName: string = 'PokerAnalyzer';

@Injectable({
  providedIn: 'root'
})
export class PokerAnalyzerService {

  constructor(private _http: HttpClient) { }

  getNewPokerGame(numberOfPlayers: number): Observable<PokerGame> {
    return this._http.post<PokerGame>(`${environment.apiEndpoint}/${controllerName}/GetNewGame`, { numberOfPlayers: numberOfPlayers }).pipe(
      take(1),
      catchError((err: HttpErrorResponse) => {
        console.log(`Error while getting new poker game: ${err.message}`);
        return of(null);
      })
    );
  }

  getExistingPokerGame(id: number): Observable<PokerGame> {
    return this._http.get<PokerGame>(`${environment.apiEndpoint}/${controllerName}/${id}`).pipe(
      take(1),
      catchError((err: HttpErrorResponse) => {
        console.log(`Error while getting poker game for id {${id}}: ${err.message}`);
        return of(null);
      })
    );
  }
  getExistingPokerGameIds(): Observable<number[]> {
    return this._http.get<number[]>(`${environment.apiEndpoint}/${controllerName}/GetExistingIds`).pipe(
      take(1),
      catchError((err: HttpErrorResponse) => {
        console.log(`Error while getting getting existing poker game ids: ${err.message}`);
        return of([]);
      })
    );
  }

  deleteGame(id: number): Observable<boolean> {
    return this._http.delete<boolean>(`${environment.apiEndpoint}/${controllerName}/${id}`).pipe(
      take(1),
      catchError((err: HttpErrorResponse) => {
        console.log(`Error while attempting to delete poker game with id {${id}}: ${err.message}`);
        return of(false);
      })
    );
  }
}
