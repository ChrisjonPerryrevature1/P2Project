import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../Models/User';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfilePageService {

  private ApiUrl = "https://localhost:7131";
  
  constructor(private http : HttpClient) { }

  public getProfile (): Observable<User>
  {
    return this.http.get<User>(this.ApiUrl + "/api/Ecommerce/GetUserLoggedInAsync")
  }

}
