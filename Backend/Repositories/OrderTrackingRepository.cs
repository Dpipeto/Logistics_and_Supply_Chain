using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IOrderTrackingRepository
    {
        Task<IEnumerable<OrderTracking>> GetAllOrderTrackingAsync();
        Task<OrderTracking?> GetOrderTrackingByIdAsync(int id);
        Task CreateOrderTrackingAsync(string date, int orderId, int dealerId);
        Task UpdateOrderTrackingAsync(int id, string date, int orderId, int dealerId);
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
        public async Task CreateOrderTrackingAsync(string date, int orderId, int dealerId)
        {
            var order = await _context.orders.FindAsync(orderId) ?? throw new Exception("user not found");
            var dealer = await _context.dealers.FindAsync(dealerId) ?? throw new Exception("user not found");

            var orderTracking = new OrderTracking
            {
                Date = date,
                Order = order,
                Dealer = dealer,
            };
            _context.ordersTracking.Add(orderTracking);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderTrackingAsync(int id, string date, int orderId, int dealerId)
        {
            var orderTracking = await _context.ordersTracking.FindAsync(id) ?? throw new Exception("order Tracking not found");

            var order = await _context.orders.FindAsync(orderId) ?? throw new Exception("user not found");
            var dealer = await _context.dealers.FindAsync(dealerId) ?? throw new Exception("user not found");

            orderTracking.Date = date;
            orderTracking.Order = order;
            orderTracking.Dealer = dealer;

            try
            {
                _context.ordersTracking.Update(orderTracking);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
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
