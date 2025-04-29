import { Injectable } from '@angular/core';
import { ShopDetails } from '../classes/ShopDetails';
import { Product } from '../classes/Product';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopDetailsService {

  constructor(public http:HttpClient) {

   }
   shopDetailsArr:Array<ShopDetails>=new Array<ShopDetails>() 

baseUrl = "http://localhost:5144/api/ShopDetails"
buy(l:Array<ShopDetails>):Observable<number>{
  return this.http.post<number>(`${this.baseUrl}`,l)
}
update(l:Array<ShopDetails>):Observable<number>{
  return this.http.put<number>(`${this.baseUrl}`,l)
}  
 
}
