using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    public interface Customer : IBLL<Dto.Customer>
    {
        //הרשמה
        Task<int> SignIn(Dto.Customer t);
        //שליפת לקוח ע"פ ת"ז
        Task<Dto.Customer> ?GetById(string t);
    }
}
