import { Component, inject } from '@angular/core';
import { BlogService } from '../../services/blog';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-blog-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './blog-form.html'
})
export class BlogFormComponent {

  private service = inject(BlogService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  id = 0;

  model: any = {
    title: '',
    content: ''
  };

  ngOnInit() {

    const id = this.route.snapshot.params['id'];

    if (id) {
      this.id = id;
      this.service.getById(id).subscribe(res => this.model = res);
    }

  }

  save() {

    if (this.id === 0) {

      this.service.create(this.model)
        .subscribe(() => this.router.navigateByUrl('/'));

    } else {

      this.service.update(this.id, this.model)
        .subscribe(() => this.router.navigateByUrl('/'));

    }

  }

}
