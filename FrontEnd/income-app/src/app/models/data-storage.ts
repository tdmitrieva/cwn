import { User } from "./user";
import { Currency } from "./currency";
import { Injectable } from '@angular/core';

@Injectable()
export class DataStorage {
    public currentUser: User;

    public currenciesList: Array<Currency>;
}