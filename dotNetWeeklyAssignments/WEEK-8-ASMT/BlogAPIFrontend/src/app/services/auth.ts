import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { authStore } from '../store/auth';

@Injectable({ providedIn: 'root' })
export class Auth {

  private http = inject(HttpClient);
  private base = 'https://localhost:7074/api/Auth';

  login(data: any) {
    return this.http.post<any>(`${this.base}/login`, data);
  }

  register(data: any) {
    return this.http.post(`${this.base}/register`, data);
  }

  setSession(res: any) {

    authStore.setAuth(res.token, {
      id: 0,
      name: res.name,
      email: '',
      role: res.role
    });

  }

  logout() {
    authStore.logout();
  }
}