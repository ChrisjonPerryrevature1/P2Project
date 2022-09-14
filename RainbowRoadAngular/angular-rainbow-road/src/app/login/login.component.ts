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
  
  LoginService: any;

  constructor(    
    private loginService: LoginService,
    private formBuilder: FormBuilder) { }
    
    login = this.formBuilder.group({
    email: '',
    password: ''
  
  });

  onSubmit(): void {
    // Process checkout data here
    this.login = this.LoginService.clearLogin();
    this.login.reset();
  }

  ngOnInit(): void 
  {
  }

}
