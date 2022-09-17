import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Order } from '../Models/order';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  historyData:any

  GetOrderHistory(postData: {UserId: number}) {
    console.log(postData)
    this.http.post
    (
      'https://localhost:7131/api/Ecommerce/GetUsersOrderContentsHistoryUser/',
       postData
    ).subscribe((responseData: any) => {
      (this.historyData = 
        JSON.stringify(responseData, null, 2));
  } );
}
}