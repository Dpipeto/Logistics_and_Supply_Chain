using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IOrderDetailHistoriesRepository
    {
        Task<IEnumerable<OrderDetailHistories>> GetAllOrderDetailHistoriesAsync();
        Task<OrderDetailHistories?> GetOrderDetailHistoriesByIdAsync(int id);
        Task CreateOrderDetailHistoriesAsync(OrderDetailHistories orderDetailHistories);
        Task UpdateOrderDetailHistoriesAsync(OrderDetailHistories orderDetailHistories);
        Task SoftDeleteOrderDetailHistoriesAsync(int id);
    }
    public class OrderDetailHistoriesRepository : IOrderDetailHistoriesRepository
    {
        private readonly DeliveryDbContext _context;

        public OrderDetailHistoriesRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderDetailHistories>> GetAllOrderDetailHistoriesAsync()
        {
            return await _context.orderDetailHistories
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<OrderDetailHistories>> GetOrderDetailHistoriesAsync()
        {
            return await _context.orderDetailHistories
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<OrderDetailHistories?> GetOrderDetailHistoriesByIdAsync(int id)
        {
            return await _context.orderDetailHistories
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreateOrderDetailHistoriesAsync(OrderDetailHistories orderDetailHistories)
        {
            _context.orderDetailHistories.Add(orderDetailHistories);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderDetailHistoriesAsync(OrderDetailHistories orderDetailHistories)
        {
            _context.orderDetailHistories.Update(orderDetailHistories);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteOrderDetailHistoriesAsync(int id)
        {
            var orderDetailHistories = await _context.orderDetailHistories.FindAsync(id);
            if (orderDetailHistories != null)
            {
                orderDetailHistories.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
