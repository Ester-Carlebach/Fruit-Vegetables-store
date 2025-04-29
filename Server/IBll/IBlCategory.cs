using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    public interface IBlCategory : IBLL<Dto.Category>
    {
        //שליפת כל הקטגוריות
        Task<List<Dto.Category>> GetCategory();
           

    }
}
