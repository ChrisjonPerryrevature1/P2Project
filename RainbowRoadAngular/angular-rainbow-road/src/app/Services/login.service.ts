import { Injectable } from '@angular/core';
import { LoginCredentials } from '../Models/login';

@Injectable({
  providedIn: 'root'
})

export class LoginService {

  login: LoginCredentials = 
  {
    email: '',
    password: ''
  };

  constructor() { }

  clearLogin() {
    this.login;
    return this.login;
  }

}