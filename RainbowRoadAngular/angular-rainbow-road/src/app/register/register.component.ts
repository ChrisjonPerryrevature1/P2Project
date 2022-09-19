import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { RegisterService } from '../Services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private registerService: RegisterService,
    private formBuilder: FormBuilder,
    private http: HttpClient) { }

    registerForm = this.formBuilder.group({
      UserId: 0,
      email: '',
      password: ''
    });

    onSubmit(): void {
      // Process checkout data here
      this.registerService.clearRegister();
      console.warn('Your login has been successful', this.registerForm.value);
      this.registerForm.reset();
    }

  ngOnInit(): void 
  {
  }

  Register(postData: {email: string, password: string}) {
    console.log(postData)
    this.http.post
    (
      'https://localhost:7131/api/Ecommerce/RegisterUserAsync/',
       postData
    ).subscribe((responseData: any) => {
      console.log(responseData);
      window.alert("Thank you for registering! Your UserId is: "+ responseData.userId + ".\nThis will be needed for login and checkout.");
  });

}
}
