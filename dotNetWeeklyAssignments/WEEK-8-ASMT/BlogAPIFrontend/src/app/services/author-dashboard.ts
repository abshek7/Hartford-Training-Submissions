import { Injectable, inject, signal } from '@angular/core';
import { Blog } from './blog';
import { Comment } from './comment';

@Injectable({ providedIn: 'root' })
export class AuthorDashboardService {

  private blogApi = inject(Blog);
  private commentApi = inject(Comment);


  blogs = signal<any[]>([]);
  comments = signal<any[]>([]);
  loading = signal(false);

  title = signal('');
  content = signal('');
  editingId = signal<number | null>(null);

  commentText = signal('');
  replyText = signal('');
  replyTo = signal<number | null>(null);

  openBlogs = signal<number[]>([]);
  openComments = signal<number[]>([]);
  openReplies = signal<number[]>([]);


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
 

  saveBlog() {

    const title = this.title().trim();
    const content = this.content().trim();

    if (!title || !content) return;

    const request = this.editingId()
      ? this.blogApi.update(this.editingId()!, { title, content })
      : this.blogApi.create({ title, content });

    request.subscribe(() => this.resetForm());
  }

  editBlog(blog: any) {
    this.title.set(blog.title);
    this.content.set(blog.content);
    this.editingId.set(blog.id);
  }

  deleteBlog(id: number) {
    this.blogApi.delete(id).subscribe(() => this.load());
  }

  resetForm() {
    this.title.set('');
    this.content.set('');
    this.editingId.set(null);
    this.load();
  }
 

  addComment(blogId: number) {

    const text = this.commentText().trim();
    if (!text) return;

    this.commentApi.add({
      message: text,
      blogId,
      parentCommentId: null
    }).subscribe(() => {
      this.commentText.set('');
      this.load();
    });
  }

  addReply(blogId: number, parentId: number) {

    const text = this.replyText().trim();
    if (!text) return;

    this.commentApi.add({
      message: text,
      blogId,
      parentCommentId: parentId
    }).subscribe(() => {
      this.replyText.set('');
      this.replyTo.set(null);
      this.load();
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
 

  toggle(listSignal: any, id: number) {

    const list = listSignal();

    listSignal.set(
      list.includes(id)
        ? list.filter((x: number) => x !== id)
        : [...list, id]
    );
  }

  isOpen(listSignal: any, id: number) {
    return listSignal().includes(id);
  }

}