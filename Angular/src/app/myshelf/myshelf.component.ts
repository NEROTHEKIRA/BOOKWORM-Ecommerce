// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-myshelf',
//   templateUrl: './myshelf.component.html',
//   styleUrls: ['./myshelf.component.css']
// })
// export class MyshelfComponent implements OnInit {

//   constructor() { }

//   ngOnInit() {
//   }

// }

import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ProductserviceService } from '../productservice.service';
import { MyshelfProduct } from '../Model/myshelf-product';
import {Router} from '@angular/router';

@Component({
  selector: 'app-myshelf',
  templateUrl: './myshelf.component.html',
  styleUrls: ['./myshelf.component.css']
})
export class MyshelfComponent implements OnInit {

  logout()
  {
    localStorage.setItem('UserId',"0");
    this.route.navigate(['/homepage']);
  }


  MyShelfProdctArray: MyshelfProduct[];

  constructor(private fb : FormBuilder,private _typeService:ProductserviceService,private route : Router) { }
 

  ngOnInit() {

    this._typeService.GetMyshelfDetails(localStorage.getItem('UserId')).subscribe((data)=>{ this.MyShelfProdctArray =data;});

  }
  
}

