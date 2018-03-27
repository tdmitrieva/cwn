import { LoginComponent } from '../components/login-component/login.component';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from "./material.module";
import { FlexLayoutModule } from "@angular/flex-layout";
import { CommonModule } from '@angular/common';  
import { BrowserModule } from '@angular/platform-browser';
import { FinancesListComponent } from "../components/finances-list-component/finances-list.component";
import { RouterModule, Route, Router } from '@angular/router';
import { AddComponent } from "../components/add-component/add.component";

const routes: Route[] = [
    {
        path: '',
        component: LoginComponent,
    },
    {
        path: 'finances',
        component: FinancesListComponent,
    }
];


@NgModule({
  declarations: [
    LoginComponent,
    FinancesListComponent,
    AddComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    FlexLayoutModule,
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes),
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    LoginComponent,
    FinancesListComponent,
    AddComponent,
    FlexLayoutModule,
    CommonModule,
    BrowserModule
  ]
})
export class ComponentsModule { }
