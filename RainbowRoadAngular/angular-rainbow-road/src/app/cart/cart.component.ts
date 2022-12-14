import { Component, OnInit } from '@angular/core';
import { CartService } from '../Services/cart.service';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Order } from '../Models/order';
import { OrderHistoryComponent } from '../order-history/order-history.component';

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
    private http: HttpClient,
    ) { }
    

  ngOnInit(): void {
  }

  onClearCart()
  {
    this.items = this.cartService.clearCart();
  }  

  onSubmit(postData : {UserId: number, OrderId: number, order: Order}) {
    postData.OrderId = 0;
    //console.log(this.items)
    //console.log(postData.UserId)
    postData.order = {
    OrderId : 0,
    ItemName : "Red Brick",
    Quantiy: 1,
    Price: 1,
    UserId: 1
    }

    for(let i=0; i<this.items.length; i++)
    {
        //console.log(this.items[i])
        this.http.put
        ('https://localhost:7131/api/Ecommerce/UpdateInventoryAsync/',this.items[i]).subscribe((responseData: any) => {console.log(responseData);});
    }

    console.log(this.items)

    for(let i=0; i<this.items.length; i++)
    {   
        postData.order.OrderId = postData.OrderId;
        postData.order.ItemName = this.items[i].ItemName;
        postData.order.Quantiy = this.items[i].Quantity;
        postData.order.Price = this.items[i].Price;
        postData.order.UserId = postData.UserId;

        console.log(postData.order)
        //console.log(this.items[i])
        this.http.post
        ('https://localhost:7131/api/Ecommerce/CreateOrderAsync/',(postData.order)).subscribe((responseData: any) => {console.log(responseData);});

    }
   
    this.items = this.cartService.clearCart();
    console.warn('Your order has been submitted');
    window.alert("Your order has been submitted, thank you for your purchase!" );

    //this.postForm.clear();
  }

}
