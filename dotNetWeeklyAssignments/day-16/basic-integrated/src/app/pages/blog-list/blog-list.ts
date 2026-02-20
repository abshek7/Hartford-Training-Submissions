import { Component, inject, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BlogService } from '../../services/blog';
import { Blog } from '../../models/blog';

@Component({
  selector: 'app-blog-list',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './blog-list.html'
})
export class BlogListComponent {

  private service = inject(BlogService);

  blogs = signal<Blog[]>([]);
  loading = signal(true);

  ngOnInit() {
    this.load();
  }

  load() {
    this.loading.set(true);

    this.service.getAll().subscribe(res => {
      this.blogs.set(res);
      this.loading.set(false);
    });
  }

  delete(id: number) {
    this.service.delete(id).subscribe(() => this.load());
  }
}
