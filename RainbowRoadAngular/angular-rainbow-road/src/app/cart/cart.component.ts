import { Component, OnInit } from '@angular/core';
import { CartService } from '../Services/cart.service';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})

export class CartComponent implements OnInit {

  items = this.cartService.getItems();
  //items needs to be passed through a http put request to 
  //create an order and update inventory request in onSubmit()

  constructor(
    private cartService: CartService,
    private formBuilder: FormBuilder,
    ) { }
    
    checkoutForm = this.formBuilder.group({
      name: '',
      address: ''
    });
    

  ngOnInit(): void {
  }

  onSubmit(): void {
    // Process checkout data here
    //http post create new order
    //http put update inventory by subtracting cart quanitites
    this.items = this.cartService.clearCart();
    console.warn('Your order has been submitted', this.checkoutForm.value);
    this.checkoutForm.reset();
  }

}
