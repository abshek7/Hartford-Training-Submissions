import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { authStore } from '../store/auth';

export const authGuard: CanActivateFn = () => {

  const router = inject(Router);

  if (!authStore.isLoggedIn()) {
    router.navigate(['/login']);
    return false;
  }

  return true;
};