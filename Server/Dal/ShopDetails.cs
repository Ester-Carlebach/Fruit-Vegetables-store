using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ShopDetails : IDal.ShopDetails
    {
        models.ShopContext db;
        public ShopDetails(models.ShopContext db)
        {
            this.db = db;
        }
        //הוספת פרטי קניה
        public Task<int> Buy(List<ShopDetail> l)
        {
            db.ShopDetails.AddRange(Converters.ShopDetailsConvert.ToModelList(l));
            return db.SaveChangesAsync();
        }


    }
}
