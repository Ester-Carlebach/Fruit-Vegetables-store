using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;

namespace IDal
{
    public interface Shop:IDallServices<Dto.Shop>
    {
        //הוספת קניה
        public Task<int> Add(Dto.Shop sh);
        //SQL עדכון התשלום ב
        public Task<int> Update(int id,Dto.Shop s);


    }
}
