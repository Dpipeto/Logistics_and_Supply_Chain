using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class Dealer_DbContext : DbContext
    {
        public Dealer_DbContext(DbContextOptions options):  base()
        { 

        }
        public DbSet<Dealer> dealers { get; set; }
    }
}
