using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IBll.product pr;
        public ProductController(IBll.product p)
        {
            this.pr = p;

        }
        [HttpGet]
        public async Task<List<Dto.Product>> GetPruduct()
        {
            return await pr.GetProduct();
        }
        //ע"מ שהקוד יהיה חלק מהניתוב-חובה
        [HttpGet("{id}")]
        public async Task<Dto.Product> GetById(int id)
        {
            return await pr.GetById(id);
        }
        //למניעת התנגשות נרחיב את שם הניתוב
        [HttpGet("byCategory")]
        public async Task<List<Dto.Product>> GetByCompanyAndCategory(int? cat, int? comp)
        {
            return await pr.GetByCompanyAndCategory(cat,comp);
        }
        //כנל
        [HttpGet("top")]
        public async Task<List<Dto.Product>> GetTop()
        {
            return await pr.GetTopProduct();
        }
   
    }
}
