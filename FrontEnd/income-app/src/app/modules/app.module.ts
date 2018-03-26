import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Route } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ComponentsModule } from "./components.module";
import { MaterialModule } from "./material.module"
import { AppComponent } from '../app.component';
import { LoginService } from "../services/login-service";
import { HttpClientModule } from '@angular/common/http';
import { NavigationConstants } from "../common/navigation-constants";
import { HttpModule } from '@angular/http';
import { FinanceService } from "../services/finance-service";
import { CurrencyService } from "../services/currency-service";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule,
    MaterialModule,
    ComponentsModule,
    HttpModule,
    HttpClientModule
  ],
  exports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule,
    MaterialModule,
    ComponentsModule,
    HttpClientModule
  ]
  ,
  providers: [
    NavigationConstants,
    LoginService,
    FinanceService,
    CurrencyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
