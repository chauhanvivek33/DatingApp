import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_model/User';



@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl=environment.baseUrl;

  constructor(private http :HttpClient) { }

  getusers():Observable<User[]>
  {
    return this.http.get<User[]>(this.baseUrl+"users");
  }
  getuser(id):Observable<User>
  {
    return this.http.get<User>(this.baseUrl+"users/"+id);
  }
}
