import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  ToggleRegister = false;
  constructor() { }

  ngOnInit() {
  }
  ToggleRegisterfunc() {
this.ToggleRegister = !this.ToggleRegister;
  }
  cancleRegister(mode: boolean) {
    this.ToggleRegister = mode;
  }
}
