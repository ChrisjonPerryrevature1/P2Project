import { Injectable } from '@angular/core';
import { Product } from '../Models/products';


@Injectable({
  providedIn: 'root'
})
export class CartService {

  items: Product[] = [];

  addToCart(product: Product) {
    this.items.push(product);
  }

  getItems() {
    return this.items;
  }

  clearCart() {
    this.items = [];
    return this.items;
  }

  itemsCount(){
    return this.items.length;
  }
  constructor() { }
}
