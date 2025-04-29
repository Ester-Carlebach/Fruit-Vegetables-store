using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    public interface product:IBLL<Dto.Product>
    {
        //שליפת כל המוצרים
       public Task<List<Product>> GetProduct();
        //שליפת ה-10 המוצרים המעודכנים ביותר
        public Task<List<Product>> GetTopProduct();
        //שליפת מוצר ע"פ קוד
        public Task<Dto.Product> GetById(int id);
        //סינון ע"פ חברה או קטגוריה
       public Task<List<Dto.Product>> GetByCompanyAndCategory(int? cat,int? comp);

    }
}
