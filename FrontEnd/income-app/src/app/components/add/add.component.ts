import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Currency } from "../../models/currency";
import { CurrencyService } from "../../services/currency-service";
import { Finance } from "../../models/finance";

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  @Output('addFinanceEvent') addFinanceEvent = new EventEmitter<Finance>(); 

  finance = new Finance();
  currencyList = new Array<Currency>();

  constructor(private currencyService: CurrencyService) {
    this.currencyService.getCurrencies().subscribe((result) => {
      this.currencyList = result;
    });
   }

  ngOnInit() {
  }

  public onAddClick() {
    this.addFinanceEvent.emit(this.finance);
  }

}
