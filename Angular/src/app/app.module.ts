import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AddproductComponent } from './addproduct/addproduct.component';
import {  HttpClientModule } from '@angular/common/http';
import { HomepageComponent } from './homepage/homepage.component';
import { RegisterformComponent } from './registerform/registerform.component';
import { UserComponent } from './user/user.component';
import { CategoryComponent } from './category/category.component';
import { AdminComponent } from './admin/admin.component';
import { BeneficiaryComponent } from './beneficiary/beneficiary.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { MyshelfComponent } from './myshelf/myshelf.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    AddproductComponent,
    HomepageComponent,
    RegisterformComponent,
    UserComponent,
    CategoryComponent,
    AdminComponent,
    BeneficiaryComponent,
    PurchaseComponent,
    MyshelfComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule, 
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
