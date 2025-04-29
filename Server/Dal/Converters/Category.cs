using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    public class Category
    {
        public static Dto.Category ToCaregoryDto(models.Category c)
        {
            Dto.Category cNew = new Dto.Category();
            cNew.CatId = c.CatId;
            cNew.CatName = c.CatName;
            cNew.CompId=c.CompId;
            cNew.CompName = c.Comp.CompName;
            return cNew;
        }

        public static List<Dto.Category> ToListDto(List<models.Category> lc)
        {
            List<Dto.Category> lnew = new List<Dto.Category>();
            foreach (models.Category c in lc)
            {
                lnew.Add(ToCaregoryDto(c));
            }
            return lnew;
        }

        public static models.Category ToCategory(Dto.Category c)
        {
            models.Category cNew = new models.Category();
            cNew.CatId = c.CatId;
            cNew.CatName = c.CatName;
            cNew.CompId = c.CompId;
            cNew.Comp = new models.Company();
            cNew.Comp.CompName = c.CompName;
            return cNew;
        }
    }
}
