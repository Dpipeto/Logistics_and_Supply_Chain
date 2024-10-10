using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync();
        Task<OrderDetail?> GetOrderDetailByIdAsync(int id);
        Task CreateOrderDetailAsync(string deliveryTime);
        Task UpdateOrderDetailAsync(int id, string deliveryTime);
        Task SoftDeleteOrderDetailAsync(int id);
    }
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DeliveryDbContext _context;

        public OrderDetailRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync()
        {
            return await _context.ordersDetail
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailAsync()
        {
            return await _context.ordersDetail
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<OrderDetail?> GetOrderDetailByIdAsync(int id)
        {
            return await _context.ordersDetail
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreateOrderDetailAsync(string deliveryTime)
        {
            var orderDetail = new OrderDetail
            {
                DeliveryTime = deliveryTime
            };

            _context.ordersDetail.Add(orderDetail);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderDetailAsync(int id, string deliveryTime)
        {
            var orderDetail = await _context.ordersDetail.FindAsync(id) ?? throw new Exception("Order Detail not found");

            orderDetail.DeliveryTime = deliveryTime;
            try
            {
                _context.ordersDetail.Update(orderDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task SoftDeleteOrderDetailAsync(int id)
        {
            var orderDetail = await _context.ordersDetail.FindAsync(id);
            if (orderDetail != null)
            {
                orderDetail.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
