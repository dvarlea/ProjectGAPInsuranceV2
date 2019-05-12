import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // properties
  baseUrl: string;
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient,  @Inject('BASE_URL') url: string, private router: Router) {
    this.baseUrl = url.concat('api/auth/');;
  }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', user.id);
          localStorage.setItem('role', user.role);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model);
  }

  loggedIn() {
    // first get the jwt token from localStorage. In this project the token is named 'token'
    const token = localStorage.getItem('token');
    // isTokenExpired returns a boolen of TRUE if the token is expired, missing, or not a jwt token
    return !this.jwtHelper.isTokenExpired(token);
  }

  isAdmin(){
    if(parseInt(localStorage.getItem('role')) == roles.admin)
    {
      return true;
    }
    return false;
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    localStorage.removeItem('role');
    //this.alertify.message('Logged Out');
  }
}

enum roles{
  admin,
  client
}
