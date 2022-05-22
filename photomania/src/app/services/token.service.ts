import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { tokenNotExpired } from 'angular2-jwt';
import * as jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor() { }

  public setToken(token: string) {
    localStorage.setItem("token", token);
  }

  public clearStore() {
    localStorage.clear();
  }

  public getToken() {
    return localStorage.getItem("token");
  }

  public getUserId() {
    const helper = new JwtHelperService();
    const token = this.getToken()

    const decodedToken = helper.decodeToken(token ? token : '');

    return decodedToken.Id;
  }

  public getRole() {
    const helper = new JwtHelperService();
    const token = this.getToken()

    const decodedToken = helper.decodeToken(token ? token : '');

    return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
  }

  public getUserName() {
    const helper = new JwtHelperService();
    const token = this.getToken()

    const decodedToken = helper.decodeToken(token ? token : '');

    return decodedToken.UserName;
  }

  public isAuthenticated(): boolean {
    const helper = new JwtHelperService();
    const token = this.getToken()

    const decodedToken = helper.decodeToken(token ? token : '');

    console.log(decodedToken);

    const isExpired = helper.isTokenExpired(token ? token : '');

    return !isExpired;
  }
}
