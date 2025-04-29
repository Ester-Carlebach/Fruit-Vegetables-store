using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
   public class Product
    {

        public static Dto.Product ToPruductsDto(models.Product p)
        {
            Dto.Product pNew = new Dto.Product();
            pNew.ProdId = p.ProdId;
            pNew.ProdName = p.ProdName;
            pNew.CatCode=p.CatCode;
            pNew.CompanyCode=p.CompanyCode;
            pNew.Description = p.Description;
            pNew.Price=p.Price; 
            pNew.Image=p.Image;
            pNew.StockQty=p.StockQty;
            pNew.LastUpdated=p.LastUpdated;
            return pNew;
        }

        public static List<Dto.Product> ToListPruductsDto(List<models.Product> pr)
        {
            List<Dto.Product> pnew = new List<Dto.Product>();
            foreach (models.Product p in pr)
            {
                pnew.Add(ToPruductsDto(p));
            }
            return pnew;
        }

        public static models.Product ToCompany(Dto.Product p)
        {
            models.Product pNew = new models.Product();
            pNew.ProdId = p.ProdId; 
            pNew.ProdName = p.ProdName;
            pNew.CatCode = p.CatCode;
            pNew.CompanyCode = p.CompanyCode;
            pNew.Description = p.Description;
            pNew.Price = p.Price;
            pNew.Image = p.Image;
            pNew.StockQty = p.StockQty;
            pNew.LastUpdated = p.LastUpdated;
            return pNew;
        }
    }
}
