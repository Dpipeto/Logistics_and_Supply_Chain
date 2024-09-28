using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task SoftDeleteOrderAsync(int id);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly DeliveryDbContext _context;

        public OrderRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _context.orders
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrderAsync()
        {
            return await _context.orders
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.orders
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreateOrderAsync(Order order)
        {
            _context.orders.Add(order);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderAsync(Order order)
        {
            _context.orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteOrderAsync(int id)
        {
            var order = await _context.orders.FindAsync(id);
            if (order != null)
            {
                order.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
