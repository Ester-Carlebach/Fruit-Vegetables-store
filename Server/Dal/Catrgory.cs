using Dal.models;
using IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Catrgory:IDallCategory
    {

        ShopContext db;
        public Catrgory(ShopContext db)
        {
            this.db = db;
        }
        //שליפת כל הקטגוריות
        public async Task<List<Dto.Category>> GetCategory()
        {
            var q = await db.Categories.Include("Comp").ToListAsync();
            return Converters.Category.ToListDto(q); 
        }

        
    }
}
