import { Injectable } from '@angular/core';
import { Customer } from '../classes/Customer';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(public http:HttpClient) { }
  baseUrl = "http://localhost:5144/api/Customer"
  // קריאת שרת של הרשמה
  signIn(cust:Customer):Observable<number>{
    return this.http.post<number>(this.baseUrl,cust)
  }
  //קריאת שרת של קבלת לקוח ע"פ ID
  getById(id:String):Observable<Customer>{
    return this.http.get<Customer>(`${this.baseUrl}/${id}`)
  }
//  המשתמש הנוכחי
  currentUser?:Customer =undefined;
   
}
