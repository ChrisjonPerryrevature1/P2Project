using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using P2EFAPI.Models;

namespace P2EFAPI

{
    public class ECommContext : DbContext
    {
        public ECommContext(DbContextOptions<ECommContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }   
    }
}
