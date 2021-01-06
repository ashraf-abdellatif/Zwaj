import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/_Model/user';
import { UserService } from 'src/app/_services/User.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {

  constructor(private userservice: UserService) { }
  @Input() user: User;
  ngOnInit() {
  }

}
