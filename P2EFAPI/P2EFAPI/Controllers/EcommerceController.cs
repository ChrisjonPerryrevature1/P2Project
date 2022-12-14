using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using P2EFAPI.Models;
using System.CodeDom;
//using System.Data.Entity;
//using Microsoft.EntityFrameworkCore

namespace P2EFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceController : ControllerBase
    {
        ECommContext _context;
        public EcommerceController(ECommContext ecommcontext)
        {
            _context = ecommcontext;
        }


        [HttpGet("GetAllUsersAsync")]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            return Ok(await _context.Users.ToListAsync()); 
        }

        [HttpGet("GetUserLoggedInAsync")]
        public async Task<ActionResult<List<User>>> GetUserLoggedInAsync()
        {
            var user = await _context.Users.ToListAsync();
            var loggedInUser = user.Where(u => u.LoggedIn == true).ToList();
            if (loggedInUser == null)
            {
                return BadRequest("User not logged in");
            }
      
            return Ok(loggedInUser);
        }


        [HttpPost("LoginAsync")]
        public async Task<ActionResult<User>> LoginAsync(LoginDto login)
        {
            var user = await _context.Users.FindAsync(login.userLoginId);
            if (user == null)
                return BadRequest("User not found.");
            if ( user.Password != login.userLoginPassword)
                return BadRequest("Incorrect email or password.");
            user.LoggedIn = true;
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("Logout")]
        public async Task<ActionResult<User>> LogoutAsync(LogOutDto userId)
        {
            var user = await _context.Users.FindAsync(userId.UserId);
            if (user?.LoggedIn == true)
            {
                user.LoggedIn = false;
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            else
            {
                return BadRequest("User is not logged in.");
            }
        }

        [HttpPost("RegisterUserAsync")]
        public async Task<ActionResult<List<User>>> RegisterUserAsync(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPut("UpdateUserAsync")]
        public async Task<ActionResult<List<User>>> UpdateUserAsync(User update)
        {
            var user = await _context.Users.FindAsync(update.UserId);

            if (user == null)
                return BadRequest("User not found.");

            user.Email = update.Email;
            user.Password = update.Password;
            user.LoggedIn = update.LoggedIn;    

            await _context.SaveChangesAsync();
            return Ok(user);
        }


        [HttpGet("GetInventoryAsync")]
        public async Task<ActionResult<List<Inventory>>> GetAllInventoryAsync()
        {
            return Ok(await _context.Inventories.ToListAsync());
        }

        [HttpPut("UpdateInventoryAsync")]
        public async Task<ActionResult<List<Inventory>>> UpdateInventoryAsync(Inventory update)
        {
            var inventory = await _context.Inventories.FindAsync(update.ItemId);

            if (inventory == null)
                return BadRequest("Item not found.");

            inventory.Quantity = inventory.Quantity - update.Quantity;
            await _context.SaveChangesAsync();
            return Ok(inventory);
        }

        [HttpPost("CreateOrderAsync")]
        public async Task<ActionResult<Order>> CreateOrderAsync(Order newOrder)
        {
            newOrder.Quantity = 1;
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return Ok(newOrder);
        }

        [HttpPost("GetUsersOrderContentsHistoryUser")]
        public async Task<ActionResult<List<Order>>> GetUsersOrderContentsHistoryAsync(HistoryDto UserId)
        {
            //var user = await _context.Users.FindAsync(UserId.UserId);
            //if (user == null)
            //    return BadRequest("User not found.");
            //if (user.LoggedIn != true)
            //    return BadRequest("User not logged in");

            //var orderhistory = await _context.Orders.Where(u => u.UserId == UserId.UserId).ToList();
            //if (orderhistory == null)
            //    return BadRequest("No order history found.");
            //return Ok(orderhistory);


            //var user = await _context.Users.ToListAsync();
            //for(int i =0; i <user.Count; i++)
            //{
            //    if(user[i].LoggedIn == false)
            //    {
            //        user.Remove(user[i]);
            //    }
            //}
            var HistoryByUser = _context.Orders.Where(u => u.UserId == UserId.UserId).ToList();
            if (HistoryByUser == null)
            {
                return BadRequest("User history not found");
            }

            return Ok(HistoryByUser);
        }


    }
}
