import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from '../_services/Auth.service';

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
        console.log('تم التسجيل بنجاح');
      },
      error => {
        console.log(error);
      }
    )
  }
  cancle() {
this.CancleRegister.emit( false);
  }
}
