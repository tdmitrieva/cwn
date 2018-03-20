import { Component, OnInit } from '@angular/core';
import { LoginService } from "../../services/login-service";
import { FinanceService } from "../../services/finance-service";
import { Finance } from "../../models/finance";

@Component({
  selector: 'app-finances-list-component',
  templateUrl: './finances-list.component.html',
  styleUrls: ['./finances-list.component.css']
})

export class FinancesListComponent implements OnInit {

  financesList: Array<Finance>;

  displayedColumns = ['Date', 'Amount', 'Currency'];

  constructor(private loginService: LoginService,
              private financeService: FinanceService) { }

  ngOnInit() {
    this.financeService.getFinances(this.loginService.currentUser.Email).subscribe((result) =>{
      this.financesList = result;
    });
  }

}

export interface Element {
  Amount: number;
  Date: string;
  Currency: string;
}