import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor(private http: HttpClient , private router: Router) { }

BaseURL = environment.Url + 'Auth/';

Login(UserData: any) {
  return this.http.post(this.BaseURL + 'login' , UserData).pipe(
   map((resonse: any) => {
    const user = resonse;
    localStorage.setItem('token', user.token);
    this.router.navigate(['/member']);
   }));
   }
Register(UserData: any) {
  return this.http.post(this.BaseURL + 'register' , UserData);
}
}
