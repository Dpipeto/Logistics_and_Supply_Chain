using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class Order_DetailDbContext : DbContext
    {
        public Order_DetailDbContext(DbContextOptions options) : base()
        {

        }
        public DbSet<Order_Detail> order_detail { get; set; }
    }
}