using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class PermissionsDbContext : DbContext
    {
        public PermissionsDbContext(DbContextOptions options) : base()
        {

        }
        public DbSet<Permissions> permissions { get; set; }
    }
}