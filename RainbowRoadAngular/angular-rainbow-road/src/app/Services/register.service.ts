import { Injectable } from '@angular/core';
import { Register } from '../Models/register';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  register: Register = 
  {
    UserId: 0,
    email: '',
    password: ''
  };

  constructor() { }

  clearRegister() {
    this.register;
    return this.register;}

  }
