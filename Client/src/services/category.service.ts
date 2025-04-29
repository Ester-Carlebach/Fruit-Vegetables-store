import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../classes/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(public h:HttpClient) { 
   
  }
  
   basicUrl:String="http://localhost:5144/api/Category"
    getCategory():Observable<Array<Category>>
    {    
      return this.h.get<Array<Category>>(`${this.basicUrl}`)
    }
}
