using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2EFAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; } = false;
    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
    }

    public class Inventory
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; } 

    }

    public class LoginDto
    {
        public int userLoginId { get; set; }    
        public string userLoginPassword { get; set; }
    }

}
