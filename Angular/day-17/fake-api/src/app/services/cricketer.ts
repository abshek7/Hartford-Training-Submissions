import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cricketer } from '../models/cricketer';

@Injectable({
  providedIn: 'root'
})
export class CricketerService {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:3000/cricketers';

  getAllCricketers() {
    return this.http.get<Cricketer[]>(this.apiUrl);
  }

  getCricketerById(id: number) {
    return this.http.get<Cricketer>(`${this.apiUrl}/${id}`);
  }

  addCricketer(cricketer: Cricketer) {
    return this.http.post<Cricketer>(this.apiUrl, cricketer);
  }

  deleteCricketer(id: number) {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}