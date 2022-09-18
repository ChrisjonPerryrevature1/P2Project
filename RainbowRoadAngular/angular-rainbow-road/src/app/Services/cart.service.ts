import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../Models/products';
import { HttpClient } from '@angular/common/http';
import { Order } from '../Models/order';


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

  addQuantities()
  {
    return this.items
  }
  // updateInventory(ItemId: number, Quantity: number){
  //   return this.http.put("https://localhost:7131/api/Ecommerce/UpdateInventoryAsync/", null);
  // }

  // createOrder(order: any) : Observable<any>
  // {
  //     return this.http.post("https://localhost:7131/api/Ecommerce/CreateOrderAsync", order).subscribe();
  // }

  constructor(private http : HttpClient) { }


}
