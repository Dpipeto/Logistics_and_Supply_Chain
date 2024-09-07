using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class Order_Status_TypeDbContext : DbContext
    {
        public Order_Status_TypeDbContext(DbContextOptions options) : base()
        {

        }
        public DbSet<Order_Status_Type> order_Status_Types { get; set; }
    }
}
