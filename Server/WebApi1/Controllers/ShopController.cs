using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBll;
using Microsoft.Extensions.Configuration;
namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        IBll.Shop c;
        public ShopController(Shop c)
        {
            this.c = c;

        }
        [HttpPost]
        public async Task<Dto.Receipt> Colcolation(Dto.Shop shop)
        {
            return await c.Colculation(shop);
        }
        //למניעת התנגשות נרחיב את שם הניתוב
        [HttpPost("add")]
        public async Task<int> Add(Dto.Shop s)
        {
            var x = await c.Add(s);
            Console.WriteLine();
            return x;
        }
        //ע"מ שהקוד יהיה חלק מהניתוב-חובה
        [HttpPut("{id}")]
        public async Task<int> Update(int id,Dto.Shop s)
        {
            return await c.Update(id,s);
        }
        //post  של תשלום כרטיס אשראי
        //POST של פרטי משלוח המעדכן בטבלת משלוחים את הקניה
    }
}
