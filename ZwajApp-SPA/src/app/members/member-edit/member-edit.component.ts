import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_Model/user';
import { AuthService } from 'src/app/_services/Auth.service';
import { UserService } from 'src/app/_services/User.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  userDecoded:any
  user:User;
  constructor(private authservice:AuthService , private userService:UserService) { }

  ngOnInit() {
    this.authservice.DecodeJwt();
    this.userDecoded = this.authservice.decodedtoken;
    this.LoadUserData();
  }
  LoadUserData() {
    this.userService.GetByID(+this.userDecoded.userid).subscribe(
      (user: User) => {
        this.user = user;
        console.log(user);
      },
      (error) => { console.log(error); }
    );
  }
  UpdateUser()
  {
    this.userService.UpDateUser(+this.userDecoded.userid , this.user).subscribe(
      () => {
        console.log("تم التعديل بنجاح");
      },
      (error) => { console.log(error); }
    );    
  }
}
