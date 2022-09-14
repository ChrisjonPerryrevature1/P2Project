import { Component, OnInit } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { LoginCredentials } from '../Models/login';
import { LoginService } from '../Services/login.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
