import { Injectable, inject, signal } from '@angular/core';
import { Blog } from './blog';
import { Comment } from './comment';

@Injectable({ providedIn: 'root' })
export class ReaderDashboardService {

  private blogApi = inject(Blog);
  private commentApi = inject(Comment);

  blogs = signal<any[]>([]);
  comments = signal<any[]>([]);
  loading = signal(false);

 
  selectedBlogId = signal<number | null>(null);
  showComments = signal(false);

  load() {
    this.loading.set(true);

    this.blogApi.getAll().subscribe(res => {
      this.blogs.set(res);
      this.loading.set(false);
    });

    this.commentApi.getAll().subscribe(res => {
      this.comments.set(res);
    });
  }

  selectBlog(blogId: number) {
    this.selectedBlogId.set(blogId);
    this.showComments.set(false);
  }

  openComments() {
    this.showComments.set(true);
  }

  closeView() {
    this.selectedBlogId.set(null);
    this.showComments.set(false);
  }

  addComment(blogId: number, message: string, parentId?: number | null) {

    const text = message.trim();

    if (!text) throw new Error('Empty message');

    return this.commentApi.add({
      message: text,
      blogId,
      parentCommentId: parentId ?? null
    });
  }

  getComments(blogId: number) {
    return this.comments()
      .filter(c => c.blogId === blogId && !c.parentCommentId);
  }

  getReplies(commentId: number) {
    return this.comments()
      .filter(c => c.parentCommentId === commentId);
  }

  getSelectedBlog() {
    return this.blogs()
      .find(b => b.id === this.selectedBlogId());
  }
}