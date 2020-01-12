// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-user',
//   templateUrl: './user.component.html',
//   styleUrls: ['./user.component.css']
// })
// export class UserComponent implements OnInit {

//   constructor() { }

//   ngOnInit() {
//   }

// }

import { Component, OnInit } from '@angular/core';
import{FormControl,FormGroup,FormBuilder,Validators}from'@angular/forms';
import { ProductserviceService } from '../productservice.service';
import {Route, Router} from '@angular/router';


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  loginform:FormGroup;
  User_Id : number;
  url : string = '';
  email : string;
  password : string;
  submitted : boolean = false;
  UserId : number ;
  
  constructor(private fb : FormBuilder ,private _typeService:ProductserviceService,private route : Router) { 
    this.loginform = fb.group({
      password:['',[Validators.required,Validators.minLength(4),Validators.maxLength(12)]],
      email:['',[Validators.required,Validators.email]]
      });
  }
  CheckUserDetail(loginform : FormGroup)
  {
    
    this.email = loginform.controls['email'].value;
    this.password = loginform.controls['password'].value;
    this.CheckUser(this.email,this.password);
    //alert(this.UserId);    
  }
  
  CheckUser(email:string , password:string)
  {
    if(this.email == "admin@gmail.com" && this.password == "admin")
    {
      this.route.navigate(['admin']);
    }

    this.url='';
    this.url = this.url+"/"+email+"/"+password;
    this._typeService.GetUserDetail(this.url).subscribe((data)=>{
     // alert(data);
     if(data>0)
  {
    
    alert("Successful");
    localStorage.setItem('UserId',data.toString());
   this.route.navigate(['/purchase']);
    
  }
  else if(this.email != "admin" && this.password != "admin" && data == 0){
    //alert(data+"Unsuccessful");
    alert("Invalid Email or password");
    this.route.navigate(['/user']);
  }
      this.UserId =data;
     // alert(this.UserId);
     
    });
    this.submitted=true;
    
  }

  ngOnInit() {
  }

}
