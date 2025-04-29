using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    public class ShopConvert
    {
        public static models.Shop  ToModel(Dto.Shop s)
        {
            models.Shop sh=new models.Shop();
            sh.ShopDate = s.ShopDate;
            sh.ShopNote = s.ShopNote;
            sh.CustomerCode = s.CustomerCode;
            sh.TotalAmount = s.TotalAmount;
            sh.IsPay = s.IsPay;
            return sh;
        }
    }
}
