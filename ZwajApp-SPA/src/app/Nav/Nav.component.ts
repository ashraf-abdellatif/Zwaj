import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/Auth.service';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.scss']
})
export class NavComponent implements OnInit {

  UserData: any = {};
  constructor(private service: AuthService) { }

  ngOnInit() {
  }

  Login() {
    this.service.Login(this.UserData)
      .subscribe(next => {
        console.log('تم الدخول بنجاح');
      } ,
      err => {
        console.log('خطا فى الدخول');
      });
  }
}
