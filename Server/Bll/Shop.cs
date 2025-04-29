using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Shop : IBll.Shop
    {
        IDal.Shop shopDal;
        public Shop(IDal.Shop shopDal)
        {
            this.shopDal = shopDal;
        }
        //פונקצית חישוב
        //הלקוח שולח אוביקט קניה המכיל מוצרי קניה ולקוח
        //ע"פ יום הולדת ומבצעים שונים מחשב את הסכום הסופי
        //ומחזיר ללקוח אוביקט קניה עם הנתונים
        public async Task<Receipt> Colculation(Dto.Shop shop)
        {
            Receipt r = new Receipt();
            double sum = 0;
            //מעבר על כל המוצרים וחישוב סכומם
            for(int i=0;i< shop.AllProducts.Count;i++)
            { 
                sum += Convert.ToDouble(shop.AllProducts[i].Product.Price * shop.AllProducts[i].Quantity);
            }
            r.Sum = sum;
            //r.TotalSum = sum;
            //בדיקה אם זה החודש של יום ההולדת של הלקוח
            int month = DateTime.Today.Month;
            if (shop.Customer.CustDateOfBirth.Value.Month == month)
            {
                r.Birthday = true;
                // birthday להכפיל במשתנה המבצע 
                //TotalSum*=
            }

            //להכפיל במשתנה המבצע
            r.TotalSum = sum - 20;
            r.SumDiscount = r.Sum - r.TotalSum;

            return r; 
        }
        //קריאה לפונקציה של הוספת הקניה
        public async Task<int> Add(Dto.Shop shop)
        {
            shop.CustomerCode = shop.Customer.CustId;
            return await shopDal.Add(shop);
        }
        //קריאה לפונקציה של עדכון הקניה
        public async Task<int> Update(int i,Dto.Shop s)
        {
            return await shopDal.Update(i,s);
        }
    }
}
