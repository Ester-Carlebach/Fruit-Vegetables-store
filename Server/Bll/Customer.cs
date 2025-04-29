using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Customer : IBll.Customer
    {

        IDal.IDallCustomer dalC;
        public Customer(IDal.IDallCustomer c)
        {
            this.dalC = c;
        }
        //קריאה לפונקצית שליפת לקוח ע"פ ת.ז
        public async Task<Dto.Customer>? GetById(string id)
        {
            return await dalC.GetById(id);
        }
        //קריאה לפונקצית הרשמה
        public async Task<int> SignIn(Dto.Customer t)

        {
            if (t == null ||t.CustDateOfBirth==null)
                return 0;
            //if (t.CustEmail)
            /// בדיקת תקינות של אימייל!!!
            var x = await dalC.GetById(t.CustId);
            if ( x!= null)
                 return 0;

            return await dalC.SignIn(t);
        }
    }
}
