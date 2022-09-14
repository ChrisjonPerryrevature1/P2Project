import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { LoginCredentials } from '../Models/login';
import { LoginService } from '../Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  constructor(    
    private loginService: LoginService,
    private formBuilder: FormBuilder) { }
    
    login = this.formBuilder.group({
    email: '',
    password: ''
  
  });

  onSubmit(): void {
    // Process checkout data here
    this.loginService.clearLogin();
    console.warn('Your login has been successful', this.login.value);
    this.login.reset();
  }

  ngOnInit(): void 
  {
  }

}
