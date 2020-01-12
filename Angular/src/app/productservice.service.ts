import { UserInfo } from './Model/UserInfo';
import { Product } from './Model/Product';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TypePoco } from './Model/Type';
import { Language } from './Model/Language';
import { Category } from './Model/Categoty';
import { ProductParamJoin } from './Model/product-param-join';
import { MyshelfProduct } from './Model/myshelf-product';
import { Beneficiary } from './Model/Beneficiary';

@Injectable({
  providedIn: 'root'
})
export class ProductserviceService {

constructor(private http: HttpClient) { }

//********************************************************************************************************/
CategoryWiseGetListURL : string="http://localhost:51164/Service1.svc/CategoryWiseGetList";
GetUSerListURL : string="http://localhost:51164/Service1.svc/GetUserDetail";
AddInvoiceDtailURL : string = "http://localhost:51164/Service1.svc/AddInvoice";
GetMyshelfDetailURL : string = "http://localhost:51164/Service1.svc/GetMyShelfProduct";
//********************************************************************************************************/
GetAllTypeListURL : string="http://localhost:51164/Service1.svc/GetAllTypeList";
GetAllLanguageListURL : string="http://localhost:51164/Service1.svc/GetAllLanguageList";
GetAllCategoryListURL : string="http://localhost:51164/Service1.svc/GetAllCategoryList";
GetAllBookListURL : string="http://localhost:51164/Service1.svc/GetBookList";
SendAllProductDetailsURL :string ="http://localhost:51164/Service1.svc/AddProduct";
UpdateProductDetailsURL :string="http://localhost:51164/Service1.svc/UpdateProduct";

//********************************************************************************************************
GetProduct(url: string): Observable<ProductParamJoin[]>
{
  alert(this.CategoryWiseGetListURL + url)
  return this.http.get<ProductParamJoin[]>(this.CategoryWiseGetListURL + url)
}
GetMyshelfDetails(url: string): Observable<MyshelfProduct[]>
{
  alert(this.GetMyshelfDetailURL+'/'+ url)
  return this.http.get<MyshelfProduct[]>(this.GetMyshelfDetailURL+'/'+ url)
}
GetUserDetail(url: string): Observable<number>
{
  alert(this.GetUSerListURL + url)
  return this.http.get<number>(this.GetUSerListURL + url)
}
AddInvoiceDetails(obj:Object):Observable<Boolean>
{
  alert("Add invoice detail");
  console.log(obj);
return this.http.post<Boolean>(this.AddInvoiceDtailURL,obj);
}
//*********************************************************************************************************
GetAllBookList(): Observable<Product[]> {
   return this.http.get<Product[]>(this.GetAllBookListURL)
 }

GetAllTypeList(): Observable<TypePoco[]> {
  return this.http.get<TypePoco[]>(this.GetAllTypeListURL)
}

GetAllLanguageList(): Observable<Language[]> {
  return this.http.get<Language[]>(this.GetAllLanguageListURL)
}

GetAllCategoryList(): Observable<Category[]> {
  return this.http.get<Category[]>(this.GetAllCategoryListURL)
}

SendAllProductDetails(Product_send_ref:Product):Observable<Boolean>
{
 return this.http.post<Boolean>(this.SendAllProductDetailsURL,Product_send_ref);
}


//********************Akshta **************************************/
SendAllRegistrationDetailsURL : string="http://localhost:51164/Service1.svc/AddUser";
SendAllRegistrationDetails(UserInfo:UserInfo):Observable<Boolean>
{
  return this.http.post<Boolean>(this.SendAllRegistrationDetailsURL,UserInfo);
}
//-----
SendAllProductBeneficiaryDetailsURL :string="http://localhost:51164/Service1.svc/AddProductBeneficiary";
SendAllBeneficiaryDetails(BenfObj: Beneficiary): Observable<Boolean>
{
  return this.http.post<Boolean>(this.SendAllProductBeneficiaryDetailsURL,BenfObj);
}
//********************-------------**************************************/

/*
UpdateAllProductDetails(Product_update_ref:Product): Observable<Product> {
  return this.http.post<Product>("http://localhost:50774/Service1.svc/UpdateEmployee",Product_update_ref)
}
*/


}