using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class PermissionXuserTypeDbContext : DbContext
    {
        public PermissionXuserTypeDbContext(DbContextOptions options) : base()
        {

        }
        public DbSet<PermissionXuserType> permissionXuserTypes { get; set; }
    }
}