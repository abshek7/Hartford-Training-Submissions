import { HttpInterceptorFn } from '@angular/common/http';
import { authStore } from '../store/auth';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

  const token = authStore.token();

  if (token) {
    req = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    });
  }

  return next(req);

};