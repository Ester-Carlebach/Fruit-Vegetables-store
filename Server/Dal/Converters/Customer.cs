using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    public class Customer
    {

        public static Dto.Customer ToDto(models.Customer c)
        {
            Dto.Customer cNew = new Dto.Customer();
            cNew.CustId = c.CustId;
            cNew.CustName = c.CustName;
            cNew.CustPhone = c.CustPhone;
            cNew.CustEmail = c.CustEmail;
            cNew.CustDateOfBirth = c.CustDateOfBirth;
            return cNew;
        }
        public static models.Customer ToCustomer(Dto.Customer c)
        {
            models.Customer cNew = new models.Customer();
            cNew.CustId = c.CustId;
            cNew.CustName = c.CustName;
            cNew.CustPhone = c.CustPhone;
            cNew.CustEmail = c.CustEmail;
            cNew.CustDateOfBirth = c.CustDateOfBirth;       
            return cNew;
    }

    }
}
