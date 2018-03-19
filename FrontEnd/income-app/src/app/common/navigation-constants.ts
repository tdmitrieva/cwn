import { Injectable } from '@angular/core';

@Injectable()
export class NavigationConstants {
    public API_URL: string = 'http://localhost:3000/api/';

    public USERS_BASE: string = 'users'

    public FINANCES_BASE: string = 'finances';
}