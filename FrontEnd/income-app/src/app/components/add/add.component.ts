import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Currency } from "../../models/currency";
import { CurrencyService } from "../../services/currency-service";
import { Finance } from "../../models/finance";
import { DataStorage } from "../../models/data-storage";

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  @Output('addFinanceEvent') addFinanceEvent = new EventEmitter<Finance>(); 

  finance = new Finance();
  currencyList = new Array<Currency>();
  selectedCurrency: number;

  constructor(private currencyService: CurrencyService,
              private storageModel: DataStorage) {
    this.currencyService.getCurrencies().subscribe((result) => {
      this.currencyList = result;
      this.storageModel.currenciesList = result;
    });
   }

  ngOnInit() {
  }


  public onAddClick() {
    this.finance.Currency = this.storageModel.currenciesList.find(c => c.Id === this.selectedCurrency);
    this.addFinanceEvent.emit(this.finance);
  }

}
