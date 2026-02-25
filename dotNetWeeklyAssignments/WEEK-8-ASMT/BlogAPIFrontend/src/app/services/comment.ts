import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Comment {
  private http = inject(HttpClient);
  private base = 'https://localhost:7074/api/Comments';

  add(data: any) {
    return this.http.post(this.base, data);
  }

  getAll() {
    return this.http.get<any[]>(this.base);
  }
}