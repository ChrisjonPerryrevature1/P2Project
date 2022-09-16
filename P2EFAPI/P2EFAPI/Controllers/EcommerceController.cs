using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2EFAPI.Models;
//using Microsoft.EntityFrameworkCore

namespace P2EFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceController : ControllerBase
    {
        public static List<User> Users = new List<User>
        {
            new User
            {
                UserId = 1,
                Email = "m@g.com",
                Password = "password123",
                LoggedIn = false
            }
        };
        public static List<Inventory> InventoryStock = new List<Inventory>
        {
            new Inventory
            {
                ItemId= 1001,
                ItemName = "The Rainbow Brick",
                Quantity = 1,
                Price = 1.00M
            }
        };
        //public static List<Order> OrderOrders = new List<Order>
        //{
        //    new Order
        //    {
        //        OrderId = 1,
        //        List<Inventory> OrderContents = List<1001, "The Rainbow Brick", 1, 1.00M>,
        //        FK_UserId =1
        //    }
        //};



        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            return Ok(Users);
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            var user = Users.Find(u => u.UserId == id);
            if (user == null)
                return BadRequest("User not found.");
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> LoginAsync(User login)
        {
            var user = Users.Find(u => (u.Email == login.Email) && (u.Password == login.Password));
            return Ok(login);
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<List<User>>> RegisterUserAsync(User newUser)
        {
            Users.Add(newUser);
            return Ok(Users);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<List<User>>> UpdateUserAsync(User update)
        {
            var user = Users.Find(u => u.UserId == update.UserId);

            if (user == null)
                return BadRequest("User not found.");

            user.Email = update.Email;
            user.Password = update.Password;
            user.LoggedIn = update.LoggedIn;

            return Ok(Users);
        }


        [HttpGet("GetInventory")]
        public async Task<ActionResult<List<Inventory>>> GetAllInventoryAsync()
        {
            return Ok(InventoryStock);
        }

        [HttpPut("UpdateInventory")]
        public async Task<ActionResult<List<Inventory>>> UpdateInventoryAsync(Inventory update)
        {
            var inventory = InventoryStock.Find(i => i.ItemId == update.ItemId);

            if (inventory == null)
                return BadRequest("Item not found.");

            inventory.Quantity = inventory.Quantity - update.Quantity;
            return Ok(inventory);
        }


    }
}
