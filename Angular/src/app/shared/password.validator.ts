import { AbstractControl } from "@angular/forms";

export function PasswordValidator(control: AbstractControl): { [key: string]:boolean } | null {
     const password = control.get('Password');
     const confirmpassword = control.get('ConfirmPassword');
     if (password.pristine || confirmpassword.pristine) {
          return null;
     }
     return password && confirmpassword && password.value !== confirmpassword.value ?
     { 'misMatch' : true} : 
     null;
}