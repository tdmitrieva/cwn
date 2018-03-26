import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { NavigationConstants } from "../common/navigation-constants";
import { Currency } from "../models/currency";

@Injectable()
export class CurrencyService {
  constructor(private http: HttpClient,
  private navigationConstants: NavigationConstants) { }

  public getCurrencies(): Observable<Array<Currency>> {
      return this.http.get<Array<Currency>>(this.navigationConstants.API_URL + this.navigationConstants.CURRENCIES_BASE);
  }

}