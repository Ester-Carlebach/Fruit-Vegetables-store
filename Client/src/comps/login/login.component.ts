import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';
import { Customer } from '../../classes/Customer';
import { CustomerService } from '../../services/customer.service';
import Swal from "sweetalert2"
import { scan } from 'rxjs';
import { ButtonComponent } from '../button/button.component';
@Component({
    selector: 'app-login',
    standalone:true,
    imports: [FormsModule,CommonModule,ButtonComponent],
    templateUrl: './login.component.html',
   
    styleUrls: ['./login.component.css']
})
export class LoginComponent {
    newC?:Customer=new Customer();
    isPopupVisible = false;

constructor(public custSer:CustomerService) {
    
}
// בדיקה אם להציג את הפופאפ
    replaceVis() {
        this.isPopupVisible = !this.isPopupVisible;
    }

    onSubmit() {
        // הרשמה
        this.custSer.signIn(this.newC!).subscribe(
            x=> {
                if(x==1){
                    Swal.fire({
                        title: 'נרשמת בהצלחה',
                        icon:"success"
                })
                this.custSer.currentUser=this.newC
                this.newC=undefined;
                }
                else if(x==0)
                     {
                        Swal.fire({
                            title: 'ההרשמה נכשלה',
                            text: 'נראה כי הינך רשום במערכת',
                            icon:"info"
                    })
                    this.custSer.getById(this.newC!.CustId!).subscribe(
                        x=>{this.custSer.currentUser=x}
                    )
                    this.newC=undefined;

                     }
                else
                Swal.fire({
                    title: 'ההרשמה נכשלה',
                    icon:"error"
            })
                
            }
            , err=> console.log(err.message) 
        )
        this.replaceVis(); 
    }
}
