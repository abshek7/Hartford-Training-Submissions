import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class User {

  private http = inject(HttpClient);
  private base = 'https://localhost:7074/api/users';

  getAll() {
    return this.http.get<any[]>(this.base);
  }
}