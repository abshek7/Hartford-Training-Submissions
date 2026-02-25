import { inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Blog } from '../models/blog';
import { tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({ providedIn: 'root' })
export class BlogService {

  private http = inject(HttpClient);
  private api = `${environment.BASE_URL}/api/Blogs`
  private blogsSignal = signal<Blog[] | null>(null);

  getAll(): Observable<Blog[]> {

    if (this.blogsSignal()) {
      return of(this.blogsSignal()!);
    }

    return this.http.get<Blog[]>(this.api).pipe(
      tap(data => this.blogsSignal.set(data))
    );
  } 
  getById(id: number): Observable<Blog> {
    return this.http.get<Blog>(`${this.api}/${id}`);
  } 
  create(data: any) {

    return this.http.post(this.api, data).pipe(
      tap(() => this.invalidateCache())
    );
  }
 
  update(id: number, data: any) {

    return this.http.put(`${this.api}/${id}`, data).pipe(
      tap(() => this.invalidateCache())
    );
  }
 
  delete(id: number) {

    return this.http.delete(`${this.api}/${id}`).pipe(
      tap(() => this.invalidateCache())
    );
  } 
  private invalidateCache() {
    this.blogsSignal.set(null);
  }

}
