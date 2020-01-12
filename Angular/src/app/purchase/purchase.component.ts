// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-purchase',
//   templateUrl: './purchase.component.html',
//   styleUrls: ['./purchase.component.css']
// })
// export class PurchaseComponent implements OnInit {

//   constructor() { }

//   ngOnInit() {
//   }

// }

import { Component, OnInit } from '@angular/core';
import { ProductserviceService } from '../productservice.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {
obj:Object;
InvoiceDetail : Object;
  constructor(private _typeService: ProductserviceService ,private router : Router) { }

  senddata()
  {
  this.obj =
  {
  "ProductMaster_Prod_Id":localStorage.getItem('ProductMaster_Prod_Id'),
  "Prod_saleprice" : localStorage.getItem('Prod_saleprice'),
  "UserId" : localStorage.getItem('UserId')
  }
    this.SendInvoice(this.obj);
  }
goToShelf()
{
  this.router.navigate(['/myshelf']);
}

SendInvoice(obj:Object)
{
  //alert("send invoice");
  //console.log(this.obj);
  this._typeService.AddInvoiceDetails(obj).subscribe((data)=>{ this.InvoiceDetail =data;

  if(data)
  {
    alert("PURCHASE SUCCESSFUL !!");
    this.router.navigate(['/myshelf']);
    //localStorage.setItem('UserId',null);
  }
  else
  {
    alert("PURCHASE FAILED , PLEASE TRY AGAIN");
  }
  });

}
logout()
{
  localStorage.setItem('UserId',"0");
  this.router.navigate(['/homepage']);
}
  ngOnInit() {

  }

}