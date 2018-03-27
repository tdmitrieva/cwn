import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { NavigationConstants } from "../common/navigation-constants";
import { Finance } from "../models/finance";
import { Observable } from "rxjs/Observable";

@Injectable()
export class FinanceService {
  constructor(private http: HttpClient,
  private navigationConstants: NavigationConstants) { }

  public getFinances(email: string): Observable<Array<Finance>> {
      return this.http.get<Array<Finance>>(this.navigationConstants.API_URL + this.navigationConstants.FINANCES_BASE + '?email=' + email);
  }

  public addFinance(email: string, finance: Finance): Observable<Finance>{
    return this.http.post<Finance>(this.navigationConstants.API_URL + this.navigationConstants.FINANCES_BASE, {
      email: email,
      finance: finance
    });
  }

  public deleteFinance(id: number) {
    return this.http.delete(this.navigationConstants.API_URL + this.navigationConstants.FINANCES_BASE + '/' + id);
  }

}