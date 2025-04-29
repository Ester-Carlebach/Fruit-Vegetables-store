import { Injectable } from '@angular/core';
import { ShopDetails } from '../classes/ShopDetails';
import { Observable } from 'rxjs';
import { Receipt } from '../classes/Receipt';
import { HttpClient } from '@angular/common/http';
import { Shop } from '../classes/Shop';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
baseUrl:String ="http://localhost:5144/api/Shop"
  newShop:Shop=new Shop()
  constructor(public http:HttpClient) { }
  colculation(sd:Shop):Observable<Receipt>{
    const r=this.http.post<Receipt>(`${this.baseUrl}`,sd)
    return r;
  }
  addShop(sd:Shop):Observable<number>{
    const r=this.http.post<number>(`${this.baseUrl}/add`,sd)
    return r;
  }
  update(id:number,s:Shop):Observable<number>{
    return this.http.put<number>(`${this.baseUrl}/${id}`,s)
  }

  // אוביקט החשבונית
  res:Receipt=new Receipt();
}
