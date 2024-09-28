using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IOrderTrackingRepository
    {
        Task<IEnumerable<OrderTracking>> GetAllOrderTrackingAsync();
        Task<OrderTracking?> GetOrderTrackingByIdAsync(int id);
        Task CreateOrderTrackingAsync(OrderTracking orderTracking);
        Task UpdateOrderTrackingAsync(OrderTracking orderTracking);
        Task SoftDeleteOrderTrackingAsync(int id);
    }
    public class OrderTrackingRepository : IOrderTrackingRepository
    {
        private readonly DeliveryDbContext _context;

        public OrderTrackingRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderTracking>> GetAllOrderTrackingAsync()
        {
            return await _context.ordersTracking
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<OrderTracking>> GetOrderTrackingAsync()
        {
            return await _context.ordersTracking
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<OrderTracking?> GetOrderTrackingByIdAsync(int id)
        {
            return await _context.ordersTracking
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreateOrderTrackingAsync(OrderTracking orderTracking)
        {
            _context.ordersTracking.Add(orderTracking);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderTrackingAsync(OrderTracking orderTracking)
        {
            _context.ordersTracking.Update(orderTracking);
            await _context.SaveChangesAsync();
        }
        public async Task SoftDeleteOrderTrackingAsync(int id)
        {
            var orderTracking = await _context.ordersTracking.FindAsync(id);
            if (orderTracking != null)
            {
                orderTracking.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
