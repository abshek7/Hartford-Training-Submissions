
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-product-detail',
  imports: [],
  templateUrl: './product-detail.html',
  styleUrl: './product-detail.css',
})
 
export class ProductDetail implements OnInit {
  productId: string | null = null;
  product: any = null;

  products = [
    { id: 101, name: 'Laptop', price: '$999', description: 'High performance laptop with latest processor' },
    { id: 102, name: 'Phone', price: '$699',   description: 'Latest smartphone with amazing camera' },
    { id: 103, name: 'Headphones', price: '$199',  description: 'Wireless headphones with noise cancellation' },
    { id: 104, name: 'Watch', price: '$399', description: 'Smart watch with fitness tracking' },
    { id: 105, name: 'Camera', price: '$799',   description: 'Professional digital camera' },
    { id: 106, name: 'Tablet', price: '$499',   description: 'Tablet device for work and entertainment' }
  ];

  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get('id');

    if (this.productId) {
      this.product = this.products.find(
        p => p.id === Number(this.productId)
      );
    }
  }

  goBack() {
    this.router.navigate(['/products']);
  }
}
