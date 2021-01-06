import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_Model/user';
import { UserService } from 'src/app/_services/User.service';

@Component({
  selector: 'app-memberlist',
  templateUrl: './memberlist.component.html',
  styleUrls: ['./memberlist.component.scss']
})
export class MemberlistComponent implements OnInit {

  constructor(private userservice: UserService) { }
  users: User[];
    ngOnInit() {
      this.GetAllUser();
    }
  GetAllUser() {
    this.userservice.getAllUser().subscribe(
      res => {
        this.users = res as User[];
        },
      () => {
        console.log('erorr in get Members List');
      }
    );
  }

}
