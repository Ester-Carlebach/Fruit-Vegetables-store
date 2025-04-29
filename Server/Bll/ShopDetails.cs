using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class ShopDetails : IBll.ShopDetails
    {
        IDal.ShopDetails sd;
        public ShopDetails(IDal.ShopDetails sd)
        {
            this.sd = sd;
        }
        //קריאה לפונקציה של עדכון פרטי קניה
        public Task<int> Buy(List<ShopDetail> l)
        {
            return sd.Buy(l);
        }

 
    }
}
