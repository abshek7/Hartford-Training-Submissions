import { Routes } from '@angular/router';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { PublicDashboard } from './components/public-dashboard/public-dashboard';
import { AdminDashboard } from './components/admin-dashboard/admin-dashboard';
import { AuthorDashboard } from './components/author-dashboard/author-dashboard';
import { ReaderDashboard } from './components/reader-dashboard/reader-dashboard';
import { roleGuard } from './guards/role-guard';
import { authGuard } from './guards/auth-guard';

export const routes: Routes = [
  { path: '', component: PublicDashboard },

  { path: 'login', component: Login },
  { path: 'register', component: Register },

  {
    path: 'admin',
    component: AdminDashboard,
    canActivate: [authGuard, roleGuard(['Admin'])]
  },
  {
    path: 'author',
    component: AuthorDashboard,
    canActivate: [authGuard, roleGuard(['Author'])]
  },
  {
    path: 'reader',
    component: ReaderDashboard,
    canActivate: [authGuard, roleGuard(['Reader'])]
  }
];