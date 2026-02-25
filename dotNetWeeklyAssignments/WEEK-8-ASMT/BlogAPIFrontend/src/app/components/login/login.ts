import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Auth } from '../../services/auth';

@Component({
  standalone: true,
  imports: [FormsModule,RouterLink],
  templateUrl: './login.html'
})
export class Login {

  private auth = inject(Auth);
  private router = inject(Router);

  email = signal('');
  password = signal('');
  error = signal('');
 
  num1 = signal(0);
  num2 = signal(0);
  captchaAnswer = signal('');
  captchaError = signal('');

  constructor() {
    this.generateCaptcha();
  }

  generateCaptcha() {
    this.num1.set(Math.floor(Math.random() * 10) + 1);
    this.num2.set(Math.floor(Math.random() * 10) + 1);
  }

  validateCaptcha(): boolean {
    const expected = this.num1() + this.num2();
    if (Number(this.captchaAnswer()) !== expected) {
      this.captchaError.set('Captcha incorrect');
      this.generateCaptcha();
      return false;
    }
    this.captchaError.set('');
    return true;
  }

  login() {

    if (!this.validateCaptcha()) return;

    this.auth.login({
      email: this.email(),
      password: this.password()
    }).subscribe({
      next: res => {

        this.auth.setSession(res);

        if (res.role === 'Admin') this.router.navigate(['/admin']);
        if (res.role === 'Author') this.router.navigate(['/author']);
        if (res.role === 'Reader') this.router.navigate(['/reader']);
      },
      error: () => this.error.set('Invalid credentials')
    });
  }
}