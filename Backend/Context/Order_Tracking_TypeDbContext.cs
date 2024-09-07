using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class Order_Tracking_TypeDbContext : DbContext
    {
        public Order_Tracking_TypeDbContext(DbContextOptions options) : base()
        {

        }
        public DbSet<Order_Tracking_Type> order_tracking_Type { get; set; }
    }
}