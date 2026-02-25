


import { Routes } from '@angular/router';
import { BlogListComponent } from './pages/blog-list/blog-list';
import { BlogFormComponent } from './pages/blog-form/blog-form';
import { BlogDetailsComponent } from './pages/blog-details/blog-details';

export const routes: Routes = [
  { path: '', component: BlogListComponent },
  { path: 'create', component: BlogFormComponent },
  { path: 'edit/:id', component: BlogFormComponent },
  { path: 'details/:id', component: BlogDetailsComponent },
];
