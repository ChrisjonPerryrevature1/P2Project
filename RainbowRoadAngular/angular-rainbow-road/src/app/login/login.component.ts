import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { LoginCredentials } from '../Models/login';
import { LoginService } from '../Services/login.service';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/user'
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  constructor(    
    private loginService: LoginService,
    private formBuilder: FormBuilder,
    private http: HttpClient) { }


  ngOnInit(): void 
  {
  }

  // onSubmit(): void {
  //   // Process checkout data here
    

  //   console.log(this.login.value);
  //   this.loginService.clearLogin();
  //   console.warn('Your login has been successful', this.login.value);
  //   this.login.reset();
  // }

  onSuccessfullLogin(postData: {userLoginId: number, Password: string}) {
    console.log(postData)
    this.http.post
    (
      'https://localhost:7131/api/Ecommerce/LoginAsync/',
       postData
    ).subscribe((responseData: any) => {
      console.log(responseData);
  });


  }}
