using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IOrderStatusTypeRepository
    {
        Task<IEnumerable<OrderStatusType>> GetAllOrderStatusTypeAsync();
        Task<OrderStatusType?> GetOrderStatusTypeByIdAsync(int id);
        Task CreateOrderStatusTypeAsync(OrderStatusType orderStatusType);
        Task UpdateOrderStatusTypeAsync(OrderStatusType orderStatusType);
        Task SoftDeleteOrderStatusTypeAsync(int id);
    }
    public class OrderStatusTypeRepository : IOrderStatusTypeRepository
    {
        private readonly DeliveryDbContext _context;

        public OrderStatusTypeRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderStatusType>> GetAllOrderStatusTypeAsync()
        {
            return await _context.ordersStatus
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<OrderStatusType>> GetOrderStatusTypeAsync()
        {
            return await _context.ordersStatus
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<OrderStatusType?> GetOrderStatusTypeByIdAsync(int id)
        {
            return await _context.ordersStatus
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreateOrderStatusTypeAsync(OrderStatusType orderStatus)
        {
            _context.ordersStatus.Add(orderStatus);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderStatusTypeAsync(OrderStatusType orderStatus)
        {
            _context.ordersStatus.Update(orderStatus);
            await _context.SaveChangesAsync();
        }
        public async Task SoftDeleteOrderStatusTypeAsync(int id)
        {
            var orderStatus = await _context.ordersStatus.FindAsync(id);
            if (orderStatus != null)
            {
                orderStatus.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
