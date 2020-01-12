import { MyshelfComponent } from './myshelf/myshelf.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { BeneficiaryComponent } from './beneficiary/beneficiary.component';
import { UserComponent } from './user/user.component';
import { RegisterformComponent } from './registerform/registerform.component';
import { HomepageComponent } from './homepage/homepage.component';
import { AddproductComponent } from './addproduct/addproduct.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoryComponent } from './category/category.component';
import { AdminComponent } from './admin/admin.component';

const routes: Routes = [


  {path:'addproduct',component: AddproductComponent},
  {path:'homepage',component: HomepageComponent},
  {path:'registration',component: RegisterformComponent},

  {path:'category',component: CategoryComponent},

  {path:'beneficiary',component: BeneficiaryComponent},

  {path:'user',component: UserComponent},

  {path:'admin',component: AdminComponent},
  {path : 'purchase' , component : PurchaseComponent},

  {path:'myshelf',component: MyshelfComponent}



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
