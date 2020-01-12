// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-category',
//   templateUrl: './category.component.html',
//   styleUrls: ['./category.component.css']
// })
// export class CategoryComponent implements OnInit {

//   constructor() { }

//   ngOnInit() {
//   }

// }

import { Component, OnInit } from '@angular/core';
import { Product } from '../Model/Product';
import { ProductserviceService } from '../productservice.service';
import { Language } from '../Model/Language';
import { TypePoco } from '../Model/Type';
import { Category } from '../Model/Categoty';
import { FormBuilder } from '@angular/forms';
import {Route, Router} from '@angular/router';
import { ProductParamJoin } from '../Model/product-param-join';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  TypePocoListArray: TypePoco[];
  LanguageListArray: Language[];
  CategoryListArray: Category[];
  ProductListArray:  ProductParamJoin[];

  store_productmasterid:number;

  url: string ='';
  finalurl: string ='';
  Cat_num : number;
  type_num :number;
  lang_num :number;
  
  
  constructor(private fb : FormBuilder,private _typeService:ProductserviceService,private route : Router) { }
  
  addProductForm=this.fb.group(
    {
      
    }
  );

  SelectCategoryFunction(Cat_Id:number)
  {
    //this.url=this.url+'/'+Cat_Id;
    //console.log(this.url);
    this.Cat_num = Cat_Id;
  }
  SelectTypeFunction(Type_Id:number)
  {
   // this.url=this.url+'/'+Type_Id;
    //console.log(this.url);
     // console.log(Type_Id);
     this.type_num = Type_Id;
  }
  SelectLanguageFunction(Lang_Id:number)
  {
    //this.url=this.url+'/'+Lang_Id;
    //console.log(this.url);
      //console.log(Lang_Id);
      this.lang_num = Lang_Id;
  }

  GetProductsByCategory()
  {
   // this.url = this.url +'/'+this.type_num+'/'+this.lang_num+'/'+this.Cat_num;
     // this._typeService.GetProduct(this.url +'/'+this.type_num+'/'+this.lang_num+'/'+this.Cat_num)
     // this.url = '';
      this._typeService.GetProduct(this.url +'/'+this.type_num+'/'+this.lang_num+'/'+this.Cat_num).subscribe
      ((data)=>{ this.ProductListArray =data;
     // console.log(this.ProductListArray[0]['p'])
      //localStorage.setItem('ProductMaster_Prod_Id',this.ProductListArray[0]['p'].ProductMaster_Prod_Id);
      localStorage.setItem('Prod_saleprice',this.ProductListArray[0]['p'].Prod_saleprice);
      });
  }
  
  Buy(tempNumber:number)
  { 
    localStorage.setItem('ProductMaster_Prod_Id',tempNumber.toString());
   if(localStorage.getItem('UserId') != "0")
   {
     this.route.navigate(['/purchase']);
   }
  else
  {
    this.route.navigate(['/user']);
  }

  }
  
  ngOnInit() {
    this._typeService.GetAllTypeList().subscribe((data)=>{ this.TypePocoListArray =data;});
    this._typeService.GetAllLanguageList().subscribe((data)=>{ this.LanguageListArray =data;});
    this._typeService.GetAllCategoryList().subscribe((data)=>{ this.CategoryListArray =data;});
  }
}
