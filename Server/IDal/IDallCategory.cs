using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface IDallCategory:IDallServices<Dto.Category>
    {
        //שליפת כל הקטגוריות
        public Task<List<Dto.Category>> GetCategory();
    }
}
