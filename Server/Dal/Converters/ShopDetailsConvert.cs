using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    public class ShopDetailsConvert
    {
        public static models.ShopDetail ToModel(Dto.ShopDetail s)
        {
            models.ShopDetail ss = new models.ShopDetail();
            ss.ShopCode = s.ShopCode;
            ss.ProductCode = s.ProductCode;
            ss.Quantity = s.Quantity;
            return ss;
        }
        public static List<models.ShopDetail> ToModelList(List<Dto.ShopDetail> l )
        {
            List<models.ShopDetail> ll = new List<models.ShopDetail>();
            foreach (var item in l)
            {
                ll.Add(ToModel(item));
            }
            return ll;
        }

    }
}
