using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface IdalPruducts:IDallServices<Dto.Product>
    {
        //שליפת כל המוצרים- מתבמעת רק כאשר לוחצים על כל המוצרים 
        public Task<List<Dto.Product>> GetProduct();
        //שליפת ה10 מוצרים המעודכנים ביותר
        public Task<List<Dto.Product>> GettopProduct();
        //שליפת מוצר ע"פ ID
        public Task<Dto.Product> GetById(int id);
        
        // שליפת מוצרים ע"פ קטגוריה או חברה
        public Task<List<Dto.Product>> GetByCompanyAndCategory(int? cat,int? comp);


    }
}
