import { Component, inject } from '@angular/core';
import { Auth } from '../../services/auth';
import { Router } from '@angular/router';
import { AdminDashboardService } from '../../services/admin-dashboard';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.html'
})
export class AdminDashboard {

  private auth = inject(Auth);
  private router = inject(Router);

  service = inject(AdminDashboardService);

  constructor() {
    this.service.load();
  }

  deleteBlog(id: number) {
    this.service.deleteBlog(id)
      .subscribe(() => this.service.load());
  }

  signout() {
    this.auth.logout();
    this.router.navigate(['/']);
  }
}