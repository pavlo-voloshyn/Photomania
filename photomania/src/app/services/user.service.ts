import { Token } from './../models/token.interface';
import { UserRegister } from './../models/user-register.interface';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseApiUrl = "http://localhost:5166/api/"

  constructor(private http: HttpClient) { }

  public register(user: UserRegister) {
    return this.http.post(this.baseApiUrl + 'user', user);
  }

  public login(username: string, password: string) {
    return this.http.post<Token>(this.baseApiUrl + 'user/login', {username, password});
  }
}
