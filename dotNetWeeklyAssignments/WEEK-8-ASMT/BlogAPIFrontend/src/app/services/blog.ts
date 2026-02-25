import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Blog {
  private http = inject(HttpClient);
  private base = 'https://localhost:7074/api/Blogs';

  getAll() {
    return this.http.get<any[]>(this.base);
  }

  create(data: any) {
    return this.http.post(this.base, data);
  }

  update(id: number, data: any) {
    return this.http.put(`${this.base}/${id}`, data);
  }

  delete(id: number) {
    return this.http.delete(`${this.base}/${id}`);
  }
}