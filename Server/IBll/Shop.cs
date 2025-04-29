using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace IBll
{
    public interface Shop
    {
        //חישוב התשלום הסופי
        public Task<Receipt> Colculation(Dto.Shop shop);
        //הוספת הקניה 
        public Task<int> Add(Dto.Shop shop);
        //עדכון התשלום
        public Task<int> Update(int i,Dto.Shop s);

    }
}
