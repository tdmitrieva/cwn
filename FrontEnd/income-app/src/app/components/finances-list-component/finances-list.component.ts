import { Component, OnInit } from '@angular/core';
import { LoginService } from "../../services/login-service";
import { FinanceService } from "../../services/finance-service";
import { Finance } from "../../models/finance";
import { DataStorage } from "../../models/data-storage";
import { MatTableDataSource } from "@angular/material/table";
import { Observable } from "rxjs/Observable";

@Component({
  selector: 'app-finances-list-component',
  templateUrl: './finances-list.component.html',
  styleUrls: ['./finances-list.component.css']
})

export class FinancesListComponent implements OnInit {

  dataSource = new MatTableDataSource<Finance>();

  displayedColumns = ['Date', 'Amount', 'Currency', 'deleteColumn'];

  constructor(private loginService: LoginService,
              private financeService: FinanceService,
              private storageModel: DataStorage) { }

  ngOnInit() {
    this.financeService.getFinances(this.storageModel.currentUser.Email).subscribe((result) => {
      this.dataSource.data = result;
    });
  }

  public addFinance(finance: Finance){
    this.financeService.addFinance(this.storageModel.currentUser.Email, finance).subscribe((financeResult) => {
      this.dataSource.data = [...this.dataSource.data, financeResult];
    });
  }

  public onRemoveClick(id : number) {
    this.financeService.deleteFinance(id).subscribe(() => {
      const itemIndex = this.dataSource.data.findIndex(f => f.Id === id);
      if (itemIndex > -1) {
        const tmpDataSource = this.dataSource.data;
        tmpDataSource.splice(itemIndex, 1);
        this.dataSource.data = tmpDataSource;
      }
    });
  }

}