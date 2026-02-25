import { Injectable, inject, signal } from '@angular/core';
import { Blog } from './blog';
import { Comment } from './comment';
import { User } from './user';

@Injectable({ providedIn: 'root' })
export class AdminDashboardService {

  private blogApi = inject(Blog);
  private commentApi = inject(Comment);
  private userApi = inject(User);

  blogs = signal<any[]>([]);
  comments = signal<any[]>([]);
  users = signal<any[]>([]);
  loading = signal(true);

  load() {

    this.loading.set(true);

    this.blogApi.getAll().subscribe(res => {
      this.blogs.set(res);
      this.loading.set(false);
    });

    this.commentApi.getAll().subscribe(res => {
      this.comments.set(res);
    });

    this.userApi.getAll().subscribe(res => {
      this.users.set(res);
    });
  }

  deleteBlog(id: number) {
    return this.blogApi.delete(id);
  }

  getComments(blogId: number) {
    return this.comments().filter(c => c.blogId === blogId);
  }

  getCommentCount(blogId: number) {
    return this.getComments(blogId).length;
  }
}