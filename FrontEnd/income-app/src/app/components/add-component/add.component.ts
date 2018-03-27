import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Currency } from "../../models/currency";
import { CurrencyService } from "../../services/currency-service";
import { Finance } from "../../models/finance";
import { DataStorage } from "../../models/data-storage";
import { FormControl, Validators, FormGroup } from '@angular/forms'

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  newFinanceFormGroup = new FormGroup({});
  transactionDateControl = new FormControl('', [Validators.required]);
  amountControl = new FormControl('', [Validators.required]);
  currencyControl = new FormControl('', [Validators.required]);

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
    this.newFinanceFormGroup.addControl('transactionDateControl', this.transactionDateControl);
    this.newFinanceFormGroup.addControl('amountControl', this.amountControl);
    this.newFinanceFormGroup.addControl('currencyControl', this.currencyControl);
  }


  public onAddClick() {
    if (this.newFinanceFormGroup.valid) {
      this.finance.Currency = this.storageModel.currenciesList.find(c => c.Id === this.selectedCurrency);
      this.addFinanceEvent.emit(this.finance);
      this.clear();
    }
    else {
      Object.keys(this.newFinanceFormGroup.controls).forEach(field => {
        const control = this.newFinanceFormGroup.get(field);
        control.markAsTouched();
      });
    }
  }

  private clear() {
    this.finance = new Finance();
    this.selectedCurrency = null;
    Object.keys(this.newFinanceFormGroup.controls).forEach(field => {
        const control = this.newFinanceFormGroup.get(field);
        control.markAsUntouched();
    });
  }

}
