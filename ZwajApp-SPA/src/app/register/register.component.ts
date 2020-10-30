import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from '../_services/Auth.service';
import * as alertify from 'alertifyjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  UserData: any = {};
  constructor(private service: AuthService) { }
  @Output() CancleRegister = new EventEmitter();
  ngOnInit() {
  }

  register() {
    this.service.Register(this.UserData).subscribe(
      result => {
        alertify.success('تم التسجيل بنجاح');
      },
      error => {
        alertify.error(error);
      }
    );
  }
  cancle() {
this.CancleRegister.emit( false);
  }
}
