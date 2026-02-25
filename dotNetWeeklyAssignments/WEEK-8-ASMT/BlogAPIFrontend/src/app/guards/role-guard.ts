import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { authStore } from '../store/auth';

export const roleGuard = (roles: string[]): CanActivateFn => {

  return () => {

    const router = inject(Router);
    const user = authStore.user();    

    if (!user || !roles.includes(user.role)) {   
      router.navigate(['/']);
      return false;
    }

    return true;
  };

};