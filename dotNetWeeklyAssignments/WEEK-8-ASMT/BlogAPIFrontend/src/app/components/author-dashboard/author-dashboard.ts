import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Auth } from '../../services/auth';
import { AuthorDashboardService } from '../../services/author-dashboard';

@Component({
  selector: 'app-author-dashboard',
  imports: [FormsModule],
  templateUrl: './author-dashboard.html'
})
export class AuthorDashboard {

  private auth = inject(Auth);
  private router = inject(Router);

  service = inject(AuthorDashboardService);

  constructor() {
    this.service.load();
  }

  signout() {
    this.auth.logout();
    this.router.navigate(['/']);
  }

}