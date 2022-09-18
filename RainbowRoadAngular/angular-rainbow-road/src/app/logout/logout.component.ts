import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { LoginService } from '../Services/login.service';
import { User } from '../Models/user';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor( private loginService: LoginService,
    private formBuilder: FormBuilder,
    private http: HttpClient) { }

  ngOnInit(): void {
  }

  logOut(postData: {UserId: number})
  {
    console.log(postData)
    this.http.post
    (
      'https://localhost:7131/api/Ecommerce/Logout/',
       postData
    ).subscribe((responseData: any) => {
      console.log(responseData);
  }); 
  }

}
