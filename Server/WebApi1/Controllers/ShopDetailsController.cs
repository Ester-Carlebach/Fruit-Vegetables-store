using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBll;
namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopDetailsController : ControllerBase
    {
        ShopDetails sd;
        public ShopDetailsController(ShopDetails sd)
        {
            this.sd = sd;
        }
        [HttpPost]
        public async Task<int> Buy(List<Dto.ShopDetail> l)
        {
            var x = await sd.Buy(l);
            return x;
        }

     }
}
