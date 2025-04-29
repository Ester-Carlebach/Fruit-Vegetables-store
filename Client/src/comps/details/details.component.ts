import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../classes/Product';
import { CurrencyPipe, JsonPipe, Location } from '@angular/common';
import { ProductService } from '../../services/product.service';
import { ButtonComponent } from '../button/button.component';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [JsonPipe,CurrencyPipe,ButtonComponent],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  p: Product = new Product()
  id: number = 0
  constructor(public ar: ActivatedRoute, public l: Location,
    public pr:ProductService) {
      //שהתקבל בניתוב ID שליפת המוצר ע"י קריאת שרת ע"פ ה-
    ar.params.subscribe(
      x => {
        this.id = x['pId'];
      }
    )
    pr.getById(this.id).subscribe(
      x=>{this.p=x},
      err=>{console.log(err.message);
      }
    )
  }
  // חזרה לדף הקודם
  back() {
    this.l.back()
  }
}
