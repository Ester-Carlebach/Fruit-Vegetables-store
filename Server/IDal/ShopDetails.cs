using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;

namespace IDal
{
    public interface ShopDetails:IDallServices<ShopDetail>
    {
        //הוספת פרטי קניה
        public Task<int> Buy(List<ShopDetail> l);
    }
}
