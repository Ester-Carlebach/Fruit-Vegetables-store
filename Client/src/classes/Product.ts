import { Category } from "./Category";
// import { Company } from "./Company";
import { Company } from "./Company";
export class Product {
    constructor(public prodId?: number,
        public prodName?: String,
        public catCode:Category=new Category(),
        public companyCode:Company=new Company(),
        public description?: String,
        public price?: number,
        public image?: string,
        public stockQty?: number,
        public lastUpdated?: Date,
    public startShop?:Boolean,
public count:number=0) { }
}
