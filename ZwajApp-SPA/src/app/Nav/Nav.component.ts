import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/Auth.service';
import * as alertify from 'alertifyjs';
@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.scss']
})
export class NavComponent implements OnInit {

  UserData: any = {};
  constructor(private service: AuthService) { }
  UserLogged = false;
  ngOnInit() {
    this.userLoggedfunc();
  }

  Login() {
    this.service.Login(this.UserData)
      .subscribe(next => {
        this.userLoggedfunc();
        alertify.success('تم الدخول بنجاح');
      } ,
      err => {
        alertify.error('خطا فى الدخول');
      });
  }
  userLoggedfunc() {
    if (localStorage.getItem('token') != null) {
    this.UserLogged = localStorage.getItem('token').length >= 0 ? true : false;
    console.log(this.UserLogged);
    } else {
    this.UserLogged = false;
    }
  }
  logout() {
localStorage.removeItem('token');
this.userLoggedfunc();
  }
}
