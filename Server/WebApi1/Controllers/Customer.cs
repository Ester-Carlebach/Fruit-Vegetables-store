using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer : ControllerBase
    {
        IBll.Customer cust;
        public Customer(IBll.Customer c)
        {
            this.cust = c;

        }

        [HttpPost]
        public async Task<int> SignIn(Dto.Customer c)
        {

            return await cust.SignIn(c);
        }
        //ע"מ שהקוד יהיה חלק מהניתוב-חובה
        [HttpGet("{id}")]
        public async Task<Dto.Customer>? GetById(string id)
        {
            return await cust.GetById(id);
        }
    }
}
