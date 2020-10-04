import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Value',
  templateUrl: './Value.component.html',
  styleUrls: ['./Value.component.scss']
})
export class ValueComponent implements OnInit {

  values: any;
  constructor( private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
  }
  getValues() {
this.http.get('https://localhost:5001/api/values/').subscribe(
  resulte => {
    this.values = resulte;
  },
  error => {
    console.log(error);
  }
);
}
}
