using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    public interface IBlCompany : IBLL<Dto.Company>
    {
        //שליפת כל החברות
        Task<List<Dto.Company>> Get();

    }
}
