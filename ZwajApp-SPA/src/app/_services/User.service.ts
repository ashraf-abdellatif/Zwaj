import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_Model/user';

const httpoptions = {
  headers: new HttpHeaders(
    {
       Authorization: 'Bearer ' + localStorage.getItem('token')
    }
  )
};
@Injectable({
  providedIn: 'root'
})
export class UserService {

constructor(private http: HttpClient) { }
BaseURL = environment.Url + 'User/';
getAllUser(): Observable<User[]> {
  return this.http.get<User[]>(this.BaseURL + 'GetAllUsers' , httpoptions);
}
GetByID(id: number): Observable<User>
{
  return this.http.get<User>(this.BaseURL + 'GetByID/' + id , httpoptions);
}
UpDateUser(id: number , user:User)
{
  return this.http.put(this.BaseURL +  id , httpoptions);
}
}
