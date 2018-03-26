import { User } from "./user";
import { Currency } from "./currency";

export class Cache {
    public currentUser: User;

    public currenciesList: Array<Currency>;
}