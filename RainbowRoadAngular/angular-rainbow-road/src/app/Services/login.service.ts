import { Injectable } from '@angular/core';
import { LoginCredentials } from '../Models/login';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Models/user';
@Injectable({
  providedIn: 'root'
})

export class LoginService {
  private ApiUrl = "https://localhost:7131";

  login: LoginCredentials = 
  {
    UserId: 0,
    password: ''
  };

  
  constructor(private http : HttpClient) { }

  clearLogin() {
    this.login;
    return this.login;
  }

  sendLogin(user:User): Observable<any>
  {
    const headers = {'content-type':'application/json'}
    const body = JSON.stringify(this.login);
    console.log(body)
    return this.http.post<User>('https://localhost:7131/api/Ecommerce/LoginAsync', body, {'headers':headers} )
  }
  // //sendLogin(): Observable<LoginCredentials>
  // sendLogin(login: LoginCredentials)
  // {
  //   //return this.http.post<LoginCredentials>(this.ApiUrl + "/api/Ecommerce/LoginAsync")
  //   this.http.post<any>(this.ApiUrl + "/api/Ecommerce/LoginAsync", login).subscribe;
  //   return this.login;
  // }

  // sendLogin()
  // {
  //   this.http.post<LoginCredentials>(this.ApiUrl + "/api/Ecommerce/LoginAsync")
  // }

  // sendLogin(login: LoginCredentials): Observable<any> {
  //   return this.http.post(this.ApiUrl + "/api/Ecommerce/LoginAsync", login);
  // }

}
