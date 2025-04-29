using Dal.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Product:IDal.IdalPruducts
    {

        models.ShopContext db;
        public Product(ShopContext db)
        {
            this.db = db;
        }
        //שליפת כל המוצרים
        public async Task<List<Dto.Product>> GetProduct()
        {
            var q = await db.Products.ToListAsync();
            return Converters.Product.ToListPruductsDto(q);
        }
        //שליפת ה10 מוצרים המעודכנים ביותר
        public async Task<List<Dto.Product>> GettopProduct()
        {
            var q = await db.Products.OrderBy(x => x.LastUpdated).Take(10).ToListAsync();
            return Converters.Product.ToListPruductsDto(q);
        }
        //שליפת מוצר ע"פ קוד
        public async Task<Dto.Product> GetById(int id)
        {
            var q =db.Products.First(x=>x.ProdId == id);
            return Converters.Product.ToPruductsDto(q);

        }
        //שליפת מוצרים ע"פ קטגוריה או חברה
        public async Task<List<Dto.Product>> GetByCompanyAndCategory(int? cat, int? comp)
        {
            if(cat!=null && comp!=null)
            {
                var q = db.Products.Where(x => x.CatCode == cat && x.CompanyCode==comp).ToList();
                return Converters.Product.ToListPruductsDto(q);
            }
           else if(cat!=null)
            {
                var q = db.Products.Where(x => x.CatCode == cat).ToList();
                return  Converters.Product.ToListPruductsDto(q);
            }
           else
            {
                var q = db.Products.Where(x => x.CompanyCode == comp).ToList();
                return Converters.Product.ToListPruductsDto(q);
            }
            

        }

    }
}
