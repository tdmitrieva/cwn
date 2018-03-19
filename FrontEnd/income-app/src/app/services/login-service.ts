import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { NavigationConstants } from "../common/navigation-constants";
import { User } from "../models/user";

@Injectable()
export class LoginService {
  constructor(private http: HttpClient,
  private navigationConstants: NavigationConstants) { }

  public currentUser: User;

  public getUser(email: string): Observable<User> {
      return this.http.get<User>(this.navigationConstants.API_URL + this.navigationConstants.USERS_BASE + '?email=' + email);
  }

}