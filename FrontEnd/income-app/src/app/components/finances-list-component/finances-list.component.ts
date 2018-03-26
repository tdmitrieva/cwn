import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
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
              private financeService: FinanceService,
              private changeDetectorRefs: ChangeDetectorRef) { }

  ngOnInit() {
    this.financeService.getFinances(this.loginService.currentUser.Email).subscribe((result) => {
      this.financesList = result;
    });
  }

  public addFinance(finance: Finance){
    this.financeService.addFinance(this.loginService.currentUser.Email, finance).subscribe(() => {
      this.financesList.push(finance);
      this.changeDetectorRefs.detectChanges();
    });
  }

}