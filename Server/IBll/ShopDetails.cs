using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;

namespace IBll
{
    public interface ShopDetails:IBLL<ShopDetail>
    {
        //הוספת פרטי הקניה
        public  Task<int> Buy(List<ShopDetail> l);
    }
}
