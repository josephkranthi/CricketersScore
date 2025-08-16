import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Cricketer {
  rank: number;
  name: string;
  score: number;
}

@Injectable({
  providedIn: 'root'   // service is available app-wide
})
export class CricketersService {

  private apiUrl = '/Cricketers';  // your ASP.NET Core endpoint

  constructor(private http: HttpClient) { }

  // GET all cricketers
  getPlayers(): Observable<Cricketer[]> {
    return this.http.get<Cricketer[]>(this.apiUrl);
  }

  // POST new cricketer
  addPlayer(player: Cricketer): Observable<Cricketer> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Cricketer>(this.apiUrl, player, { headers });
  }

  // PUT update cricketer
  updatePlayer(rank: number, player: Cricketer): Observable<void> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<void>(`${this.apiUrl}/${rank}`, player, { headers });
  }

  // DELETE cricketer
  deletePlayer(rank: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${rank}`);
  }
}
