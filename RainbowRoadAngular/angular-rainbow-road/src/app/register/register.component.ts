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
    private formBuilder: FormBuilder) { }

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

}
