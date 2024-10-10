using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IOrderStatusTypeRepository
    {
        Task<IEnumerable<OrderStatusType>> GetAllOrderStatusTypeAsync();
        Task<OrderStatusType?> GetOrderStatusTypeByIdAsync(int id);
        Task CreateOrderStatusTypeAsync(string orderStatusType);
        Task UpdateOrderStatusTypeAsync(int id, string orderStatusType);
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
        public async Task CreateOrderStatusTypeAsync(string orderStatusType)
        {
            var orderStatus = new OrderStatusType
            {
                OrderStatusTypes = orderStatusType
            };
            _context.ordersStatus.Add(orderStatus);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderStatusTypeAsync(int id, string orderStatusType)
        {
            var orderStatus = await _context.ordersStatus.FindAsync(id) ?? throw new Exception("Order Status not found");

            orderStatus.OrderStatusTypes = orderStatusType;
            try
            {
                _context.ordersStatus.Update(orderStatus);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
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
