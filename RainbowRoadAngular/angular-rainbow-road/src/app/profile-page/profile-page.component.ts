import { Component, OnInit } from '@angular/core';
import { ProfilePageService } from '../Services/profile-page.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent implements OnInit {

  userProfile: any;
  
  constructor(private PPS: ProfilePageService) { }

  ngOnInit(): void {
    this.displayUser()
  }
  

  displayUser(): void{
  {
    this.PPS.getProfile().subscribe(users => 
      (this.userProfile = 
      JSON.stringify(users, null, 2)));
  }
  }
}
