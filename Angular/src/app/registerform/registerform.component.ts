import { UserInfo } from './../Model/UserInfo';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ProductserviceService } from '../productservice.service';
import { from } from 'rxjs';
import { PasswordValidator } from '../shared/password.validator';

@Component({
  selector: 'app-registerform',
  templateUrl: './registerform.component.html',
  styleUrls: ['./registerform.component.css']
})
export class RegisterformComponent implements OnInit {
  
  ngOnInit() 
  {
   
  }

  
  submitted = false;
  constructor(private fb1: FormBuilder,private _typeService:ProductserviceService) { 

    this.createRegistrationForm();
  }

 
    createRegistrationForm(){
    this.registrationUserForm = this.fb1.group(
      {
        Name: ['', [Validators.required,Validators.minLength(5)]],
        Password: ['', [Validators.required,Validators.minLength(8),Validators.maxLength(15)]],
        ConfirmPassword:['',Validators.required],
        Email: ['', [Validators.required,Validators.email]],
        House_no: ['', Validators.required],
        Street: ['', Validators.required],
        City: ['', Validators.required],
        Pincode: ['', [Validators.required,Validators.minLength(6),Validators.maxLength(6)]],
        Landmark: [''],
        Date_of_birth: ['', Validators.required],
      }  , {validator: PasswordValidator} 
    );
  }

  registrationUserForm:FormGroup;

  onSubmit(UserInforef:FormGroup)
  {
    this.mapFormValues(UserInforef);
  }

  UserInforef:UserInfo=new UserInfo();

  mapFormValues(form:FormGroup)
{
  this.UserInforef.Name= form.controls['Name'].value ;
  this.UserInforef.Password=form.controls['Password'].value ;
  this.UserInforef.ConfirmPassword=form.controls['ConfirmPassword'].value;
  this.UserInforef.Email=form.controls['Email'].value ;
  this.UserInforef.House_no=form.controls['House_no'].value ;
  this.UserInforef.Street=form.controls['Street'].value ;
  this.UserInforef.City=form.controls['City'].value ;
  this.UserInforef.Pincode=form.controls['Pincode'].value ;
  this.UserInforef.Landmark=form.controls['Landmark'].value ;
  this.UserInforef.Date_of_birth=form.controls['Date_of_birth'].value ;


  this.sendAllRegistrationDetails(this.UserInforef);
}


sendAllRegistrationDetails(UserInforef:UserInfo)
{
  //Modal Bootstrap Pending
  this._typeService.SendAllRegistrationDetails(UserInforef).subscribe(data=>alert("DONE"));
}




get Name()
{
  return this.registrationUserForm.get('Name');
}

get Email()
{
  return this.registrationUserForm.get('Email');
}
get Password()
{
  return this.registrationUserForm.get('Password');
}
get Pincode()
{
  return this.registrationUserForm.get('Pincode');
}

get House_no()
{
  return this.registrationUserForm.get('House_no');
}

get Street()
{
  return this.registrationUserForm.get('Street');
}

get City()
{
  return this.registrationUserForm.get('City');
}

get Date_of_birth()
{
  return this.registrationUserForm.get('Date_of_birth');
}
}

