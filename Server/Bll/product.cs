using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class product:IBll.product
    {
        IDal.IdalPruducts dalp;
        public product(IDal.IdalPruducts p)
        {
            this.dalp = p;
        }

        //קריאה לפונקצית שליפת כל המוצרים
        public async Task<List<Dto.Product>> GetProduct()
        {
            return await dalp.GetProduct();
        }
        //קריאה לפונקצית שליפת מוצר ע"פ קוד
        public async Task<Product> GetById(int id)
        {
            return await dalp.GetById(id);
        }

     

        public async Task<List<Product>> GetByCompanyAndCategory(int? cat,int? comp)
        {
            return await dalp.GetByCompanyAndCategory(cat, comp);
        }

        public async Task<List<Product>> GetTopProduct()
        {
            return await dalp.GettopProduct();
        }
    }
}
