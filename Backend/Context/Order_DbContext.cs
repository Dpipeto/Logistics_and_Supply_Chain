using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class Order_DbContext : DbContext
    {
        public Order_DbContext(DbContextOptions options) : base()
        {

        }
        public DbSet<Order> orders { get; set; }
    }
}
