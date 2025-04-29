import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../classes/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(public http: HttpClient) {
  }
  basicUrl: String = "http://localhost:5144/api/Product"
  getProducts(): Observable<Array<Product>> {
    return this.http.get<Array<Product>>(`${this.basicUrl}`)
  }
  getTopProducts(): Observable<Array<Product>> {
    return this.http.get<Array<Product>>(`${this.basicUrl}/top`)
  }
  getById(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.basicUrl}/${id}`)
  }
//סינון ע""פ 2 נתונים
  getByCategoryOrCompany(cat?: number, comp?: number): Observable<Array<Product>> {
    if(cat != undefined&&comp != undefined)
      return this.http.get<Array<Product>>(`${this.basicUrl}/byCategory?cat=${cat}&comp=${comp}`)
    if (cat != undefined)
      return this.http.get<Array<Product>>(`${this.basicUrl}/byCategory?cat=${cat}`)
    else 
      return this.http.get<Array<Product>>(`${this.basicUrl}/byCategory?comp=${comp}`)
    

  }

}
