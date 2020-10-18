import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor(private http: HttpClient) { }

BaseURL = 'https://localhost:5001/api/Auth/';

Login(UserData: any) {
  return this.http.post(this.BaseURL + 'login' , UserData).pipe(
   map((resonse: any) => {
    const user = resonse;
    localStorage.setItem('token', user.token);
   }));
   }
Register(UserData: any) {
  return this.http.post(this.BaseURL + 'register' , UserData);
}
}
