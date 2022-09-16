﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using P2EFAPI.Models;
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

        [HttpGet("GetUserAsync/{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User not found.");
            return Ok(user);
        }

        [HttpPost ("LoginAsync")]
        public async Task<ActionResult<User>> LoginAsync(string userEmail, string userPassword)
        {
            //make sure the logic is working
            var user = await _context.Users.FindAsync(userEmail, userPassword);
            if (user == null)
                return BadRequest("User not found.");
            if (user.Email != userEmail || user.Password != userPassword)
                return BadRequest("Incorrect email or password.");

            user.LoggedIn = true;
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("Logout")]
        public async Task<ActionResult<User>> LogoutAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user.LoggedIn == true)
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
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return Ok(newOrder);
        }

        [HttpGet("GetUsersOrderContentsHistoryUser")]
        public async Task<ActionResult<List<Order>>> GetUsersOrderContentsHistoryAsync(int UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user == null)
                return BadRequest("User not found.");

            var orderhistory = await _context.Orders.FindAsync(user.UserId);
            if (orderhistory == null)
                return BadRequest("No order history found.");
            return Ok(orderhistory);
        }


    }
}
