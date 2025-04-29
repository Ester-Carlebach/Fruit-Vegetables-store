using Dto;
using IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Shop : IDal.Shop
    {
        models.ShopContext db;
        public Shop(models.ShopContext db)
        {
            this.db = db;
        }
        //הוספת קניה
        public async Task<int> Add(Dto.Shop shop)
        {
            var newShop = Converters.ShopConvert.ToModel(shop);
            db.Shops.Add(newShop);
            await db.SaveChangesAsync();
            return newShop.ShopId;
        }
        //עדכון קניה
        public Task<int> Update(int id, Dto.Shop s1)
        {
           var s = db.Shops.First(x => x.ShopId == id);
            s.IsPay = s1.IsPay;
            db.Shops.Update(s);
            return db.SaveChangesAsync();
        }
    }
}
