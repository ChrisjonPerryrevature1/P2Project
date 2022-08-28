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
            if (ModelState.IsValid)
            {
                // Customers customer = new Customers();
                Customers newCustomer = await this._businessLayer.RegisterCustomerAsync(customer);
                return Ok(newCustomer);
            }
            return BadRequest(customer);
        }

        [HttpPost("LoginAsync")]
        public async Task<ActionResult> LoginAsync(Customers login)
        {
            if (ModelState.IsValid)
            {
                Customers newLogin = await this._businessLayer.LoginAsync(login);
                return Ok(newLogin);
            }
            return BadRequest(login);
        }

        [HttpGet("ViewInventoryAsync")]
        public async Task<ActionResult<List<Inventory>>> ViewInventoryAsync()
        {

            List<Inventory> ViewInventory = await this._businessLayer.ViewInventoryAsync();
            return Ok(ViewInventory);

        }

        [HttpPost("FillCartAsync")]
        public async Task<ActionResult> FillCartAsync(Cart cart)
        {
            if (ModelState.IsValid)
            {
                Cart FilledCart = await this._businessLayer.FillCartAsync(cart);
                return Ok(FilledCart);
            }
            return BadRequest(cart);
        }

        [HttpPut("EditCartAsync")]
        public async Task<ActionResult> EditCartAsync(Cart cart)
        {
            if (ModelState.IsValid)
            {
                Cart editedCart = await this._businessLayer.EditCartAsync(cart);
                return Ok(editedCart);
            }
            return BadRequest(cart);

        }

        [HttpPost("ChckoutCartAsync")]
        public async Task<ActionResult> CheckoutCartAsync(CustomerIDdto customer)
        {
            if (ModelState.IsValid)
            {
                Orders orderComplete = await this._businessLayer.CheckoutCartAsync(customer);
                return Ok(orderComplete);
            }
            return BadRequest(customer);

        }


    }//EOC
}//EON
