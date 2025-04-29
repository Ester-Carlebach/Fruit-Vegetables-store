import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { Product } from '../../classes/Product';
import { ProductService } from '../../services/product.service';
import { CurrencyPipe, JsonPipe, NgClass } from '@angular/common';
import { ShopDetails } from '../../classes/ShopDetails';
import { ShopDetailsService } from '../../services/shop-details.service';
import { CategoryService } from '../../services/category.service';
import { CompanyService } from '../../services/company.service';
import { Category } from '../../classes/Category';
import { Company } from '../../classes/Company';
import { DirDirective } from '../Directive/dir.directive';
import { ButtonComponent } from '../button/button.component';
// import { cwd } from 'process';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [DirDirective, NgClass, RouterOutlet, CardModule, ButtonModule, JsonPipe, CurrencyPipe,ButtonComponent],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {
  // מערך המוצרים
  arr: Array<Product> = new Array<Product>()
  // המוצרים המוצגים
  filtArr: Array<Product> = new Array<Product>()
  // מערך הקטגוריות
  arrCategories: Array<Category> = new Array<Category>()
  // מערך החברות
  arrCompanies: Array<Company> = new Array<Company>()
  constructor(public router: Router, public p: ProductService,
    public shopDetailsService: ShopDetailsService,
    public CatService: CategoryService,
    public CompanyService: CompanyService,
  ) {
  }
  // בעת לחיצה על תמונה מנתב לפרטים נוספים
  more(n: number) {
      this.router.navigate([`./detailes/${n}`])
  }
  // בתחילה ממלא את המערכים
  ngOnInit(): void {
    this.CatService.getCategory().subscribe(x=>this.arrCategories=x)
    this.CompanyService.getCompany().subscribe(x=>this.arrCompanies=x) 
    this.p.getTopProducts().subscribe(
      d => {
        this.arr = d;
        this.filtArr = d;
        // עבור מוצר שכבר נקנה מעדכן אותו
        if(this.shopDetailsService.shopDetailsArr.length > 0){
          for(let i in this.arr){
            let c = this.shopDetailsService.shopDetailsArr.findIndex(x => x.productCode == this.arr[i].prodId)!
           if(c!=-1){
            this.arr[i]=this.shopDetailsService.shopDetailsArr[c].product            
            this.filtArr[i]=this.shopDetailsService.shopDetailsArr[c].product
           }
          }
        }
      },
      err => { console.log("error") }
    )
  }
  sd: ShopDetails = new ShopDetails()
  // בעת לחיצה על העגלה נוצר פריט חדש בחשבונית
  buyFirst(ps: Product) {
    ps.count = 1
    this.sd = new ShopDetails(0,undefined, ps.prodId, 1, ps)
    this.shopDetailsService.shopDetailsArr.push(this.sd)
  }
  i: number = 0
  // בעת לחיצה על פלוס ומינוס מעדכן את הכמות
  plus(pr: Product) {
    this.i = this.shopDetailsService.shopDetailsArr.findIndex(x => x.productCode == pr.prodId)!
    this.shopDetailsService.shopDetailsArr[this.i].product.count! += 1
    this.shopDetailsService.shopDetailsArr[this.i].quantity! += 1
  }
  minus(pr: Product) {
    this.i = this.shopDetailsService.shopDetailsArr.findIndex(x => x.productCode == pr.prodId)!
    if (this.shopDetailsService.shopDetailsArr[this.i].quantity! < 1)
      alert("אין אופציה להוריד מ-0")
    else {
      this.shopDetailsService.shopDetailsArr[this.i].quantity! -= 1
      this.shopDetailsService.shopDetailsArr[this.i].product.count! -= 1
      if(this.shopDetailsService.shopDetailsArr[this.i].quantity==0)
        this.shopDetailsService.shopDetailsArr.splice(this.i,1)
    }

  }
  x: Array<Category> = new Array<Category>()
  // מחזיר קטגוריות תואמות לקטגוריה הראשית
  filt(compId: number) {
    this.x = this.arrCategories.filter(x => x.compId == compId)
  }
//סינון ע"פ קטגוריה
  filterByCategory(id: number) {
    console.log(id);

    this.p.getByCategoryOrCompany(id,undefined).subscribe(
      d => {
        this.filtArr = d;
        console.log(this.filtArr);

      },
      err => { console.log("error") }
    )
  }
  //סינון ע"פ חברה
  filterByCompany(id: number) {
    console.log(id);

    this.p.getByCategoryOrCompany(undefined,id).subscribe(
      d => {
        this.filtArr = d;
        console.log(this.filtArr);

      },
      err => { console.log("error") }
    )
  }
  //הצגת כל המוצרים
  all() {
    this.p.getProducts().subscribe(
      x=>{this.filtArr = x,
        this.arr = x}

    )
  }
  //ביטול סינון
  cancelFilter(){
    this.filtArr=this.arr;
  }
  //מיון ע"פ מחיר
  toSort() {
    this.filtArr.sort((a: Product, b: Product) => {
      return a.price! - b.price!
    })

  }
}
