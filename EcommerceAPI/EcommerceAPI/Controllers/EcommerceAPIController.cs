using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BusinessLayer;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceAPIController : ControllerBase
    {
        private readonly EcommerceBusiness _businessLayer;
        public EcommerceAPIController()
        {
            this._businessLayer = new EcommerceBusiness();
        }

        [HttpPost("RegisterCustomerAsync")]
        public async Task<ActionResult> RegisterCustomerAsync(Customers customer)
        {
            if(ModelState.IsValid)
            {
               // Customers customer = new Customers();
                Customers newCustomer = await this._businessLayer.RegisterCustomerAsync(customer);
                return Ok(newCustomer);
            }
            return BadRequest(customer);
        }



    }
}
