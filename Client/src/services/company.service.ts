import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from '../classes/Company';
@Injectable({
  providedIn: 'root'
})
export class CompanyService {
constructor(public h:HttpClient) {


 }
   basicUrl:String="http://localhost:5144/api/Company"
    getCompany():Observable<Array<Company>>
    {    
      return this.h.get<Array<Company>>(`${this.basicUrl}`)
    }
}