import { Product } from "./Product";
import { Shop } from "./Shop";

export class ShopDetails {
    constructor(public shopDetailsId?:number,public shopCode?:number,public productCode?:number,public quantity?:number,public product:Product=new Product(),public isPay?:number) {

    }

}
