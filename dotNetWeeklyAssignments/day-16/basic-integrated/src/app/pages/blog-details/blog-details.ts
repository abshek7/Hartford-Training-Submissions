import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BlogService } from '../../services/blog';
import { CommentService } from '../../services/comment';
import { Blog } from '../../models/blog';

@Component({
  selector: 'app-blog-details',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './blog-details.html'
})
export class BlogDetailsComponent {

  private blogService = inject(BlogService);
  private commentService = inject(CommentService);
  private route = inject(ActivatedRoute);
  private router = inject(Router); 

  blog = signal<Blog | null>(null);
  loading = signal(true);

  comment = signal({
    message: '',
    author: '',
    blogId: 0
  });

  editingId = signal<number | null>(null);

  editData = signal({
    message: '',
    author: ''
  });

  constructor() {
    this.route.params.subscribe(params => {
      const id = Number(params['id']);
      this.load(id);
    });
  }
 
  goHome() {
    this.router.navigateByUrl('/');
  }

  load(id: number) {

    this.loading.set(true);

    this.blogService.getById(id).subscribe(res => {

      this.blog.set(res);

      this.comment.update(c => ({
        ...c,
        blogId: res.id
      }));

      this.loading.set(false);
    });
  }

  addComment() {

    const currentBlog = this.blog();
    const currentComment = this.comment();

    if (!currentBlog) return;
    if (!currentComment.message || !currentComment.author) return;

    this.commentService.create(currentComment)
      .subscribe(() => {

        this.comment.set({
          message: '',
          author: '',
          blogId: currentBlog.id
        });

        this.load(currentBlog.id);
      });
  }

  deleteComment(id: number) {

    const currentBlog = this.blog();
    if (!currentBlog) return;

    this.commentService.delete(id)
      .subscribe(() => this.load(currentBlog.id));
  }

  startEdit(c: any) {

    this.editingId.set(c.id);

    this.editData.set({
      message: c.message,
      author: c.author
    });
  }

  saveEdit(id: number) {

    const data = this.editData();

    this.commentService.update(id, data)
      .subscribe(() => {

        this.editingId.set(null);

        const blog = this.blog();
        if (blog) this.load(blog.id);
      });
  }

  cancelEdit() {
    this.editingId.set(null);
  }

  updateAuthor(value: string) {
    this.comment.update(c => ({
      ...c,
      author: value
    }));
  }

  updateMessage(value: string) {
    this.comment.update(c => ({
      ...c,
      message: value
    }));
  }

}
