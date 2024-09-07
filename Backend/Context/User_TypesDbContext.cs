using Microsoft.EntityFrameworkCore;

using Backend.Model;
namespace Backend.Context
{
    public class User_TypesDbContext : DbContext
    {
        public User_TypesDbContext(DbContextOptions options) : base()
        {

        }
        public DbSet<User_Types> users { get; set; }
    }
}