using Microsoft.EntityFrameworkCore;

using Backend.Model;

namespace Backend.Context
{
    public class User_DbContext : DbContext
    {
        public User_DbContext(DbContextOptions options): base()
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
            .HasKey(u => u.ID);
        }

        public DbSet<User> users { get; set; }
    }
}
