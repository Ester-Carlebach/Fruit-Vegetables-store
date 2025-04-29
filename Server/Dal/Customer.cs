using Dal.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Customer : IDal.IDallCustomer
    {

        models.ShopContext db;
        public Customer(ShopContext db)
        {
            this.db = db;
        }
        //שליפת לקוח ע"פ ת.ז
        public async Task<Dto.Customer> GetById(string id)
        {

            var  q =db.Customers.FirstOrDefault(x => x.CustId == id);

            if (q == null)
                return null;


            return  Converters.Customer.ToDto(q);
           
        }

       //הרשמה
        public async Task<int> SignIn(Dto.Customer customer)
        {

            db.Customers.Add(Converters.Customer.ToCustomer(customer));
            int x = await db.SaveChangesAsync();
            return x;
        }
    }
}
