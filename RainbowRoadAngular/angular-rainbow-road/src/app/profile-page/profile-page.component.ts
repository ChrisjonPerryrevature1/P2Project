import { Component, OnInit } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { LoginCredentials } from '../Models/login';
import { LoginService } from '../Services/login.service';
import { ProfilePageService } from '../Services/profile-page.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent implements OnInit {

  userProfile: any;
  
  constructor(private PPS: ProfilePageService) { }

  ngOnInit(): void {}
  

  displayUser()
  {
    this.PPS.getProfile().subscribe(data => 
      {
        this.userProfile = data;
      })
  }

}
