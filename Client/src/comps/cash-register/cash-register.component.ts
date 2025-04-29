import { Component } from '@angular/core';
import { ShopService } from '../../services/shop.service';
import { CustomerService } from '../../services/customer.service';
import Swal from "sweetalert2"
import {Router } from '@angular/router';
import { ShopDetailsService } from '../../services/shop-details.service';
import { ShopDetails } from '../../classes/ShopDetails';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-cash-register',
  standalone: true,
  imports: [DecimalPipe],
  templateUrl: './cash-register.component.html',
  styleUrl: './cash-register.component.css'
})
export class CashRegisterComponent {

  constructor(public shopSer: ShopService, public cust: CustomerService,public route:Router,
    public shopDet:ShopDetailsService
  ) {
console.log(shopSer.res);

  }
  update() {
    // עדכון התשלום
    this.shopSer.newShop.isPay=1
    this.shopSer.update(this.shopSer.newShop.shopId!, this.shopSer.newShop)
      .subscribe(data => {
        Swal.fire({
          title: 'הפרטים התעדכנו במערכת ',
          text: 'תודה שקניתם אצלינו:)',
          icon: "success",
        });
        this.shopDet.shopDetailsArr=new Array<ShopDetails>() 
        this.route.navigate([''])
      }
      )

  }
 
}
