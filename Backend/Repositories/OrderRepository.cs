using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(string typeOrder, string packageSender, string packageReceive, string orderValue, string senderAddress, string senderPhone, string senderEmail, int userId, int orderDetailId, int orderStatusTypeId);
        Task UpdateOrderAsync(int id, string typeOrder, string packageSender, string packageReceive, string orderValue, string senderAddress, string senderPhone, string senderEmail, int userId, int orderDetailId, int orderStatusTypeId);
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
        public async Task CreateOrderAsync(string typeOrder, string packageSender, string packageReceive, string orderValue, string senderAddress, string senderPhone, string senderEmail, int userId, int orderDetailId, int orderStatusTypeId)
        {
            var user = await _context.users.FindAsync(userId) ?? throw new Exception("user not found");
            var orderDetail = await _context.ordersDetail.FindAsync(orderDetailId) ?? throw new Exception("Order Detail not found");
            var orderStatusType = await _context.ordersStatus.FindAsync(orderStatusTypeId) ?? throw new Exception("Order Status not found");

            var order = new Order
            {
                TypeOrder = typeOrder,
                Packagesender = packageSender,
                PackageReceive = packageReceive,
                OrderValue = orderValue,
                SenderAddress = senderAddress,
                SenderPhone = senderPhone,
                SenderEmail = senderEmail,
                User = user,
                Detail = orderDetail,
                Status = orderStatusType
            };

            _context.orders.Add(order);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderAsync(int id, string typeOrder, string packageSender, string packageReceive, string orderValue, string senderAddress, string senderPhone, string senderEmail, int userId, int orderDetailId, int orderStatusTypeId)
        {
            var order = await _context.orders.FindAsync(id) ?? throw new Exception("Order not found");           

            var user = await _context.users.FindAsync(userId) ?? throw new Exception("user not found");
            var orderDetail = await _context.ordersDetail.FindAsync(orderDetailId) ?? throw new Exception("Order Detail not found");
            var orderStatusType = await _context.ordersStatus.FindAsync(orderStatusTypeId) ?? throw new Exception("Order Status not found");

            order.TypeOrder = typeOrder;
            order.Packagesender = packageSender;
            order.PackageReceive = packageReceive;
            order.OrderValue = orderValue;
            order.SenderAddress = senderAddress;
            order.SenderPhone = senderPhone;
            order.SenderEmail = senderEmail;
            order.User = user;
            order.Detail = orderDetail;
            order.Status = orderStatusType;
            try
            {
                _context.orders.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
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
