import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products',
  imports: [],
  templateUrl: './products.html',
  styleUrl: './products.css',
})
 
export class Products {
  products = [
    { id: 101, name: 'Laptop', price: '$999', description: 'High performance laptop' },
    { id: 102, name: 'Phone', price: '$699', description: 'Latest smartphone' },
    { id: 103, name: 'Headphones', price: '$199',description: 'Wireless headphones' },
    { id: 104, name: 'Watch', price: '$399',description: 'Smart watch' },
    { id: 105, name: 'Camera', price: '$799',description: 'Digital camera' },
    { id: 106, name: 'Tablet', price: '$499',description: 'Tablet device' }
  ];

  constructor(private router: Router) {}

  viewProduct(id: number) {
    this.router.navigate(['/products', id]);
  }
}