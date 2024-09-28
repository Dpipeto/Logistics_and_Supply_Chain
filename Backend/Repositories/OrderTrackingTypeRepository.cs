using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IOrderTrackingTypeRepository
    {
        Task<IEnumerable<OrderTrackingType>> GetAllOrderTrackingTypeAsync();
        Task<OrderTrackingType?> GetOrderTrackingTypeByIdAsync(int id);
        Task CreateOrderTrackingTypeAsync(OrderTrackingType orderTrackingType);
        Task UpdateOrderTrackingTypeAsync(OrderTrackingType orderTrackingType);
        Task SoftDeleteOrderTrackingTypeAsync(int id);
    }
    public class OrderTrackingTypeRepository : IOrderTrackingTypeRepository
    {
        private readonly DeliveryDbContext _context;

        public OrderTrackingTypeRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderTrackingType>> GetAllOrderTrackingTypeAsync()
        {
            return await _context.orderTrackingTypes
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<OrderTrackingType>> GetOrderTrackingTypeAsync()
        {
            return await _context.orderTrackingTypes
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<OrderTrackingType?> GetOrderTrackingTypeByIdAsync(int id)
        {
            return await _context.orderTrackingTypes
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreateOrderTrackingTypeAsync(OrderTrackingType orderTrackingType)
        {
            _context.orderTrackingTypes.Add(orderTrackingType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderTrackingTypeAsync(OrderTrackingType orderTrackingType)
        {
            _context.orderTrackingTypes.Update(orderTrackingType);
            await _context.SaveChangesAsync();
        }
        public async Task SoftDeleteOrderTrackingTypeAsync(int id)
        {
            var orderTrackingType = await _context.orderTrackingTypes.FindAsync(id);
            if (orderTrackingType != null)
            {
                orderTrackingType.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
