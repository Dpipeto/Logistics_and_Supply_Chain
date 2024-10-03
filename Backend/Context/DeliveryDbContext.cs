using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class DeliveryDbContext : DbContext
    {
        public DeliveryDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            //Builder Triggers
            modelBuilder.Entity<Order>().ToTable(tb => tb.UseSqlOutputClause(false));
            //modelBuilder.Entity<User>().ToTable(tb => tb.UseSqlOutputClause(false));
            //modelBuilder.Entity<OrderDetail>().ToTable(tb => tb.UseSqlOutputClause(false));
            //modelBuilder.Entity<OrderTracking>().ToTable(tb => tb.UseSqlOutputClause(false));
        }
        public DbSet<User> users { get; set; }
        public DbSet<UserTypes> usersTypes { get; set; }
        public DbSet<PermissionXuserType> permissionsXuser { get; set; }
        public DbSet<Permissions> permissions { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> ordersDetail { get; set; }
        public DbSet<OrderStatusType> ordersStatus { get; set; }
        public DbSet<OrderTracking> ordersTracking { get; set; }
        public DbSet<Dealer> dealers { get; set; }
        public DbSet<OrderTrackingType> orderTrackingTypes { get; set; }
        public DbSet<UserHistories> userHistories { get; set; }
        public DbSet<OrderDetailHistories> orderDetailHistories { get; set; }
        public DbSet<OrderTrackingHistories> ordersTrackingHistories { get; set; }
        public DbSet<OrderHistories> ordersHistories { get; set; }

    }
}
