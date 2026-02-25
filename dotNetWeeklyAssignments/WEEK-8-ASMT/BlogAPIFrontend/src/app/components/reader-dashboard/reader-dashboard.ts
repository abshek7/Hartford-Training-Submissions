import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Auth } from '../../services/auth';
import { Router } from '@angular/router';
import { ReaderDashboardService } from '../../services/reader-dashboard';

@Component({
  selector: 'app-reader-dashboard',
  imports: [FormsModule],
  templateUrl: './reader-dashboard.html',
})
export class ReaderDashboard {

  private auth = inject(Auth);
  private router = inject(Router);

  service = inject(ReaderDashboardService);

  commentText = signal('');
  replyText = signal('');
  replyToCommentId = signal<number | null>(null);

  constructor() {
    this.service.load();
  }

  addComment(blogId: number) {
    this.service.addComment(blogId, this.commentText())
      .subscribe(() => {
        this.commentText.set('');
        this.service.load();
      });
  }

  setReply(commentId: number) {
    this.replyToCommentId.set(commentId);
    this.replyText.set('');
  }

  addReply(blogId: number, parentId: number) {
    this.service.addComment(blogId, this.replyText(), parentId)
      .subscribe(() => {
        this.replyText.set('');
        this.replyToCommentId.set(null);
        this.service.load();
      });
  }

  signout() {
    this.auth.logout();
    this.router.navigate(['/']);
  }
}