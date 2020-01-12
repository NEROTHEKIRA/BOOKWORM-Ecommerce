import { OnInit, Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductserviceService } from '../productservice.service';
import { Beneficiary } from '../Model/Beneficiary';

@Component({
    selector: 'app-beneficiary',
    templateUrl: './beneficiary.component.html',
    styleUrls: ['./beneficiary.component.css']
  })

// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-beneficiary',
//   templateUrl: './beneficiary.component.html',
//   styleUrls: ['./beneficiary.component.css']
// })
// export class BeneficiaryComponent implements OnInit {

//   constructor() { }

//   ngOnInit() {
//   }

// }

// import { Component, OnInit } from '@angular/core';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { ProductserviceService } from '../productservice.service';
// import { Beneficiary } from '../Model/Beneficiary';

// @Component({
//   selector: 'app-beneficiary',
//   templateUrl: './beneficiary.component.html',
//   styleUrls: ['./beneficiary.component.css']
// })

export class BeneficiaryComponent implements OnInit {

  beneficiaryForm: FormGroup;

  constructor(private fb: FormBuilder,private _serviceObj: ProductserviceService) { 
    this.creteForm();
  }

  ngOnInit() {
   
  }

  creteForm()
  {
    this.beneficiaryForm = this.fb.group(
      {
        Benf_name: ['', Validators.required],
        Benf_acc_no:['',Validators.required],
        Benf_contact_no: ['',Validators.required],
        Benf_email_id: ['', Validators.required],
      }
    );
  }

  //BenfObj: Beneficiary ;
  Benfref:Beneficiary=new Beneficiary();

  onSubmit(BenfForm: FormGroup)
  {
    this.mapBeneficiaryValues(BenfForm);
  }

 
  mapBeneficiaryValues(form: FormGroup)
  {
    this.Benfref.Benf_name= form.controls['Benf_name'].value ;
    this.Benfref.Benf_acc_no= form.controls['Benf_acc_no'].value ;
    this.Benfref.Benf_contact_no= form.controls['Benf_contact_no'].value ;
    this.Benfref.Benf_email_id= form.controls['Benf_email_id'].value ;

    this.sendAllBeneficiaryDetails(this.Benfref);
  }

  get Benf_name () { return this.beneficiaryForm.get('Benf_name');} ;
  get Benf_acc_no () { return this.beneficiaryForm.get('Benf_acc_no');} ;
  get Benf_namBenf_contact_noe () { return this.beneficiaryForm.get('Benf_contact_no');} ;
  get Benf_email_id () { return this.beneficiaryForm.get('Benf_email_id');} ;

  sendAllBeneficiaryDetails(BenfObj: Beneficiary)
  {
    this._serviceObj.SendAllBeneficiaryDetails(BenfObj).subscribe(data=>alert("Beneficiary in permission"));
  }
  

}