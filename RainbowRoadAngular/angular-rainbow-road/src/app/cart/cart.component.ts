import { Component, OnInit } from '@angular/core';
import { CartService } from '../Services/cart.service';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

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
    private http: HttpClient
    ) { }
    
    checkoutForm = this.formBuilder.group({
      name: '',
      address: ''
    });
    

  ngOnInit(): void {
  }

  onSubmit(): void {
    console.log(this.items)
    for(let i=0; i<this.items.length; i++)
    {
        console.log(this.items[i])
        this.http.put
        ('https://localhost:7131/api/Ecommerce/UpdateInventoryAsync/',this.items[i]).subscribe((responseData: any) => {console.log(responseData);});
    }
   
    this.items = this.cartService.clearCart();
    console.warn('Your order has been submitted', this.checkoutForm.value);
    this.checkoutForm.reset();
  }

}
