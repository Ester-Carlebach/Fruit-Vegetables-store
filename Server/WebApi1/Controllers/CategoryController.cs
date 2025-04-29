using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IBll.IBlCategory c;
        public CategoryController(IBll.IBlCategory c)
        {
            this.c = c;

        }
        
        [HttpGet]
        public async Task<List<Dto.Category>> GetCategory()
        {
            return await c.GetCategory();
        }

    }
}
