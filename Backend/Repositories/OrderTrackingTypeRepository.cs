using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Repositories
{
    public interface IOrderTrackingTypeRepository
    {
        Task<IEnumerable<OrderTrackingType>> GetAllOrderTrackingTypeAsync();
        Task<OrderTrackingType?> GetOrderTrackingTypeByIdAsync(int id);
        Task CreateOrderTrackingTypeAsync(string ordertrackingType, int orderTrackingId);
        Task UpdateOrderTrackingTypeAsync(int id, string ordertrackingType, int orderTrackingId);
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
        public async Task CreateOrderTrackingTypeAsync(string ordertrackingType, int orderTrackingId)
        {
            var orderTracking = await _context.ordersTracking.FindAsync(orderTrackingId) ?? throw new Exception("order Tracking not found");

            var orderTrackingTypes = new OrderTrackingType
            {
                OrderTrackingTypes = ordertrackingType,
                Order_Tracking = orderTracking
            };
            _context.orderTrackingTypes.Add(orderTrackingTypes);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderTrackingTypeAsync(int id, string ordertrackingType, int orderTrackingId)
        {
            var orderTrackingTypes = await _context.orderTrackingTypes.FindAsync(id) ?? throw new Exception("OrderTracking Type not found");

            var orderTracking = await _context.ordersTracking.FindAsync(orderTrackingId) ?? throw new Exception("order Tracking not found");

            orderTrackingTypes.OrderTrackingTypes = ordertrackingType;
            orderTrackingTypes.Order_Tracking = orderTracking;

            try
            {
                _context.orderTrackingTypes.Update(orderTrackingTypes);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
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
