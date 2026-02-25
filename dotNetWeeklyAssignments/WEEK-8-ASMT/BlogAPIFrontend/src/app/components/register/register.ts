import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Auth } from '../../services/auth';
import { RouterLink } from '@angular/router';

@Component({
  imports: [FormsModule,RouterLink],
  templateUrl: './register.html'
})
export class Register {
  private auth = inject(Auth);

  name = signal('');
  email = signal('');
  password = signal('');
  role = signal('Reader');
  success = signal(false);

  register() {
    this.auth.register({
      name: this.name(),
      email: this.email(),
      password: this.password(),
      role: this.role()
    }).subscribe(() => this.success.set(true));
  }
}