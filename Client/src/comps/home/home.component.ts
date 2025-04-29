import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { FormsModule, NgForm, NgModel } from '@angular/forms';
import { NgClass, NgFor } from '@angular/common';
// import {  HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule,NgClass,NgFor],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})


export class HomeComponent implements OnInit  {
  constructor(public p:ProductService) {}
  images: string[] = ['14/14.jpg','14/112.jpg','14/109.jpg'];
  images1: string[] = ['14/36.jpg', '14/52.jpg', '14/67.jpg'];

  i:number=0
  image:String=this.images[this.i]
  image1:String="14/109.jpg"
  ngOnInit() {
    // הצגת תמונות מתחלפות
    setInterval(
      ()=>{
        this.image=this.images[(this.i+1)%this.images.length];

        this.i++;
      },2000
    )
    setInterval(
      ()=>{
        this.image1=this.images1[(this.i+2)%this.images.length];

        this.i++;
      },2000
    )
    
  }


}
