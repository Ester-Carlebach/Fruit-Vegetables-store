import { Component } from '@angular/core';
import { ShopDetailsService } from '../../services/shop-details.service';
import { ShopDetails } from '../../classes/ShopDetails';
import { Product } from '../../classes/Product';
import { NgFor } from '@angular/common';
import { ButtonComponent } from "../button/button.component";
import Swal from "sweetalert2"
import { ShopService } from '../../services/shop.service';
import { Shop } from '../../classes/Shop';
import { CustomerService } from '../../services/customer.service';
import { FormsModule } from '@angular/forms';
import { lastValueFrom } from 'rxjs';
import { Route, RouteConfigLoadEnd, Router } from '@angular/router';

@Component({
  selector: 'app-carting',
  standalone: true,
  imports: [NgFor, ButtonComponent, FormsModule],
  templateUrl: './carting.component.html',
  styleUrl: './carting.component.css'
})
export class CartingComponent {
  d: Date = new Date();
  d1: String = this.d.getFullYear() + "-";

  constructor(public shopDetailsService: ShopDetailsService, public shopSer: ShopService, public custSer: CustomerService,
    public roter: Router) {

    if (this.d.getMonth()< 10) {
      this.d1 += "0" + (this.d.getMonth() + 1);
    }
    else
      this.d1 += "" + (this.d.getMonth() + 1);
      if (this.d.getDate()< 10) {
        this.d1 += "-0" + (this.d.getDate() );
      }
   else
    this.d1 += "-" + this.d.getDate()
    console.log(this.d1);
    this.arr = shopDetailsService.shopDetailsArr

  }
  arr: Array<ShopDetails> = new Array<ShopDetails>()
  i: number = 0
  custId: String = ""
  
  // עדכון כמות
  update(pr: Product) {
    this.i = this.shopDetailsService.shopDetailsArr.findIndex(x => x.productCode == pr.prodId)!
    this.shopDetailsService.shopDetailsArr[this.i].quantity! += 1
    this.shopDetailsService.shopDetailsArr[this.i].product.count! += 1

  }
  // מחיקת מוצר
  del(pr: Product) {
    this.i = this.shopDetailsService.shopDetailsArr.findIndex(x => x.productCode == pr.prodId)!
    this.shopDetailsService.shopDetailsArr.splice(this.i, 1)
  }
  // מעבר לקופה
 async cashRegister() {
    if (this.shopDetailsService.shopDetailsArr.length == 0)
      Swal.fire({
        title: 'עדיין לא הזמנתם מהמוצרים שלנו',
        icon: "info"
      })
    else {
      if (this.custSer.currentUser == undefined) {
        if (this.custId == "") {
          Swal.fire({
            title: 'הכנס תעודת זהות ע"מ להמשיך לקופה',
            icon: "warning",
          }
          )
        }
        else {
          this.custSer.getById(this.custId).subscribe(
            data => {
              console.log(data);
              
              this.custSer.currentUser = data
              this.shopSer.newShop.customer = this.custSer.currentUser
              this.shopSer.newShop.allProducts = this.shopDetailsService.shopDetailsArr
              this.shopSer.newShop.shopDate =this.d1
              this.shopSer.newShop.isPay = 0
              this.shopSer.colculation(this.shopSer.newShop).subscribe
                (
                  x => {
                    this.shopSer.res = x
                    this.shopSer.newShop.totalAmount=x.totalSum
                    this.addShop()
                    this.roter.navigate(['./cashRegister'])

                  },
                  l => Swal.fire({
                    title: 'Oops!',
                    text: 'אתה לא רשום במערכת ',
                    icon: "warning",
                  }
                  )
                )

            },
            x => {
              Swal.fire({
                title: 'לא נמצא משתמש',
                text: 'אנא התחברו למערכת',
                icon: "warning",
              }
              )
            }

          )
        }
      }
      else {
        this.shopSer.newShop.customer = this.custSer.currentUser
        this.shopSer.newShop.allProducts = this.shopDetailsService.shopDetailsArr
        this.shopSer.newShop.shopDate =this.d1
        this.shopSer.newShop.isPay = 0        
        this.shopSer.colculation(this.shopSer.newShop).subscribe
          (
            x => {
              this.shopSer.res = x
              this.shopSer.newShop.totalAmount=x.totalSum
              this.addShop()

            },
            l => console.log(this.shopSer.newShop,l.message)
          )

        this.roter.navigate(['./cashRegister'])
      }
    }
  }
// קריאת שרת להוספת קניה
  addShop(){
    console.log(this.shopSer.newShop);
    
    this.shopSer.addShop(this.shopSer.newShop).subscribe(
      x=>{
        this.shopDetailsService.shopDetailsArr.forEach(element => {
          element.shopCode=x
        }
      );
      this.shopSer.newShop.shopId=x
      this.addShopDetails()
      console.log(this.shopDetailsService.shopDetailsArr);
      }
        ,
      y=>console.log(y)
      
    )
  }
  // קריאת שרת להוספת פרטי קניה
  addShopDetails(){
    this.shopDetailsService.buy(this.shopDetailsService.shopDetailsArr)
    .subscribe(data=>console.log(data),
    x=>console.log(x)
    )
  }
}
