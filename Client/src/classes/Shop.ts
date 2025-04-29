import { Customer } from "./Customer";
import { ShopDetails } from "./ShopDetails";

export class Shop{
   
    constructor(public shopId?:number,public customerCode?:String,public shopDate?:String,public totalAmount?:number,public shopNote?:String,
public customer?:Customer,public allProducts?:Array<ShopDetails>,public isPay?:number){
    }
}
