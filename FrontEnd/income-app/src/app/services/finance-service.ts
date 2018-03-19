import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { NavigationConstants } from "../common/navigation-constants";
import { Finance } from "../models/finance";

@Injectable()
export class FinanceService {
  constructor(private http: HttpClient,
  private navigationConstants: NavigationConstants) { }

  public getFinances(email: string): Observable<Array<Finance>> {
      return this.http.get<Array<Finance>>(this.navigationConstants.API_URL + this.navigationConstants.FINANCES_BASE + '?email=' + email);
  }

}