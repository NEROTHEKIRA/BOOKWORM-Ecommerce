import { Product } from './../Model/Product';
import { Language } from './../Model/Language';
import { TypePoco } from './../Model/Type';
import { ProductserviceService } from './../productservice.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators, Form } from '@angular/forms';
import { Category } from '../Model/Categoty';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css']
})
export class AddproductComponent implements OnInit {


  TypePocoListArray: TypePoco[];
  LanguageListArray: Language[];
  CategoryListArray: Category[];
   
constructor (private fb : FormBuilder,private _typeService:ProductserviceService )
{
this.createForm();
}

addProductForm:FormGroup;

createForm()
{
 this.addProductForm=this.fb.group({
  Prod_title:this.fb.control('',Validators.required),
  Prod_price  :this.fb.control('',Validators.required),
   Prod_saleprice :this.fb.control('',Validators.required),
   Type_Id  :this.fb.control('',Validators.required), 
   Lang_Id  :this.fb.control('',Validators.required),  
   Cat_Id  :this.fb.control('',Validators.required),
 ////  ProductMaster_Prod_Id  :this.fb.control('',Validators.required),
 Prod_specialprice  :this.fb.control('',Validators.required),
   Prod_specialprice_fromdate :this.fb.control('',Validators.required),
   Prod_specialprice_todate :this.fb.control('',Validators.required),
   Prod_short_desc :this.fb.control('',Validators.required),
   Prod_long_desc:this.fb.control('',Validators.required),
   Prod_author :this.fb.control('',Validators.required),
   Prod_img :this.fb.control('',Validators.required),
   Prod_release_date :this.fb.control('',Validators.required),
   Prod_rent :this.fb.control('',Validators.required),
   Prod_lib :this.fb.control('',Validators.required),
   Prod_rent_amt :this.fb.control('',Validators.required),
   Prod_rent_mindays :this.fb.control('',Validators.required),
   Prod_publisher :this.fb.control('',Validators.required),
 //  ProductMasterProd_Id:this.fb.control('',Validators.required)
 });
}

get Prod_title () { return this.addProductForm.get('Prod_title');} ;
get Prod_price  () { return this.addProductForm.get('Prod_price');}
get Prod_saleprice    () { return this.addProductForm.get('Prod_saleprice');}
get Type_Id  () { return this.addProductForm.get('Type_Id');} 
get Lang_Id  () { return this.addProductForm.get('Lang_Id');}  
get  Cat_Id  () { return this.addProductForm.get('Cat_Id');}
//get ProductMaster_Prod_Id  () { return this.addProductForm.get('ProductMaster_Prod_Id');}
get Prod_specialprice  () { return this.addProductForm.get('Prod_specialprice');}
get Prod_specialprice_fromdate () { return this.addProductForm.get('Prod_specialprice_fromdate');}
get Prod_specialprice_todate () { return this.addProductForm.get('Prod_specialprice_todate');}
get Prod_short_desc () { return this.addProductForm.get('Prod_short_desc');}
get Prod_long_desc() { return this.addProductForm.get('Prod_long_desc');}
get Prod_author () { return this.addProductForm.get('Prod_author');}
get Prod_img () { return this.addProductForm.get('Prod_img');}
get Prod_release_date () { return this.addProductForm.get('Prod_release_date');}
get Prod_rent () { return this.addProductForm.get('Prod_rent');}
get Prod_lib () { return this.addProductForm.get('Prod_lib');}
get Prod_rent_amt () { return this.addProductForm.get('Prod_rent_amt');}
get Prod_rent_mindays () { return this.addProductForm.get('Prod_rent_mindays');}
get Prod_publisher () { return this.addProductForm.get('Prod_publisher');}
get Prod_Id() { return this.addProductForm.get('Prod_Id');}

 productref:Product=new Product();
  
 onSubmit(productref:FormGroup)
  {
    this.mapFormValues(productref);
  }

  mapFormValues(form:FormGroup)
  {
    this.productref.Prod_title = form.controls['Prod_title'].value ;
    this.productref.Prod_price = form.controls['Prod_price'].value ;
    this.productref.Prod_saleprice   = form.controls['Prod_saleprice'].value ;
    this.productref.Type_Id= form.controls['Type_Id'].value ;
    this.productref.Lang_Id = form.controls['Lang_Id'].value ;
    this.productref.Cat_Id  = form.controls['Cat_Id'].value ;
    this.productref.Prod_specialprice  = form.controls['Prod_specialprice'].value ;
    this.productref.Prod_specialprice_fromdate= form.controls['Prod_specialprice_fromdate'].value ;
    this.productref.Prod_specialprice_todate = form.controls['Prod_specialprice_todate'].value ;
    this.productref.Prod_short_desc = form.controls['Prod_short_desc'].value ;
    this.productref.Prod_long_desc= form.controls['Prod_long_desc'].value ;
    this.productref.Prod_author = form.controls['Prod_author'].value ;
    this.productref.Prod_img = form.controls['Prod_img'].value ;
    this.productref.Prod_release_date = form.controls['Prod_release_date'].value ;
    this.productref.Prod_rent = form.controls['Prod_rent'].value ;
    this.productref.Prod_lib = form.controls['Prod_lib'].value ;
    this.productref.Prod_rent_amt = form.controls['Prod_rent_amt'].value ;
    this.productref.Prod_rent_mindays = form.controls['Prod_rent_mindays'].value ;
    this.productref.Prod_publisher = form.controls['Prod_publisher'].value ;
    //this.productref.ProductMasterProd_Id  = form.controls[' ProductMasterProd_Id'].value ;

    this.sendAllDetails(this.productref);
  }




  sendAllDetails(productref:Product)
  {
    this._typeService.SendAllProductDetails(productref).subscribe(data=>console.log("DONE"));
  }

  ngOnInit() {
   // debugger;
 this._typeService.GetAllTypeList().subscribe((data)=>{ this.TypePocoListArray =data;});
 this._typeService.GetAllLanguageList().subscribe((data)=>{ this.LanguageListArray =data;});
 this._typeService.GetAllCategoryList().subscribe((data)=>{ this.CategoryListArray =data;});
 //console.log(this.TypePocoListArray);
  }

}
