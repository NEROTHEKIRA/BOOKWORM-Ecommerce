import { Product } from './../Model/Product';
import { Component, OnInit } from '@angular/core';
import { ProductserviceService } from '../productservice.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  constructor(private _typeService:ProductserviceService) { }


  ProductBookListArray: Product[];

  ngOnInit() {
    this._typeService.GetAllBookList().subscribe((data)=>{ this.ProductBookListArray =data;});
  }

  

}