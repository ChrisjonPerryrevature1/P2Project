import { Component, OnInit } from '@angular/core';

import { products } from '../Models/products';
import { CartService } from '../Services/cart.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit{
  products: any = products;

  constructor(private cartService: CartService){}

  ngOnInit(): void {
      
  }
  addToCart(product: any) {
    this.cartService.addToCart(product);
    window.alert('Your product has been added to the cart!');
  }
}
