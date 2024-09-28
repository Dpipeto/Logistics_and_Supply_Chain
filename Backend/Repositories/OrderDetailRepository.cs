using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync();
        Task<OrderDetail?> GetOrderDetailByIdAsync(int id);
        Task CreateOrderDetailAsync(OrderDetail orderDetail);
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
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
        public async Task CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.ordersDetail.Add(orderDetail);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.ordersDetail.Update(orderDetail);
            await _context.SaveChangesAsync();
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
