using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class Order_TrackingDbContext : DbContext
    {
        public Order_TrackingDbContext(DbContextOptions options) : base()
        {

        }
        public DbSet<Order_Tracking> order_tracking { get; set; }
    }
}