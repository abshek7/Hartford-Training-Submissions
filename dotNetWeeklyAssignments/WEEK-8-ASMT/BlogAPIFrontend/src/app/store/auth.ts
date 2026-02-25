import { signal } from '@angular/core';

interface User {
  id: number;
  name: string;
  email: string;
  role: string;
}

const tokenSignal = signal<string | null>(null);
const userSignal = signal<User | null>(null);

function loadFromStorage() {

  const token = localStorage.getItem('token');
  const user = localStorage.getItem('user');

  if (token) tokenSignal.set(token);
  if (user) userSignal.set(JSON.parse(user));
}

export const authStore = {

  token: tokenSignal.asReadonly(),    
  user: userSignal.asReadonly(),      

  setAuth(token: string, user: User) {
    localStorage.setItem('token', token);
    localStorage.setItem('user', JSON.stringify(user));

    tokenSignal.set(token);
    userSignal.set(user);
  },

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');

    tokenSignal.set(null);
    userSignal.set(null);
  },

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  },

  restore() {
    loadFromStorage();
  }

};