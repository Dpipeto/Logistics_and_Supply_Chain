using Backend.Model;
using Backend.Repositories;
using Backend.Repository;

namespace Backend.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(string typeOrder, string packageSender, string packageReceive, string orderValue, string senderAddress, string senderPhone, string senderEmail, int userId, int orderDetailId, int orderStatusTypeId);
        Task UpdateOrderAsync(int id, string typeOrder, string packageSender, string packageReceive, string orderValue, string senderAddress, string senderPhone, string senderEmail, int userId, int orderDetailId, int orderStatusTypeId);
        Task SoftDeleteOrderAsync(int id);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }
        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _OrderRepository.GetAllOrderAsync();
        }
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _OrderRepository.GetOrderByIdAsync(id);
        }
        public async Task CreateOrderAsync(string typeOrder, string packageSender, string packageReceive, string orderValue, string senderAddress, string senderPhone, string senderEmail, int userId, int orderDetailId, int orderStatusTypeId)
        {
            await _OrderRepository.CreateOrderAsync(typeOrder, packageSender, packageReceive, orderValue, senderAddress, senderPhone, senderEmail, userId, orderDetailId, orderStatusTypeId);
        }
        public async Task UpdateOrderAsync(int id, string typeOrder, string packageSender, string packageReceive, string orderValue, string senderAddress, string senderPhone, string senderEmail, int userId, int orderDetailId, int orderStatusTypeId)
        {
            await _OrderRepository.UpdateOrderAsync(id, typeOrder, packageSender, packageReceive, orderValue, senderAddress, senderPhone, senderEmail, userId, orderDetailId, orderStatusTypeId);
        }
        public async Task SoftDeleteOrderAsync(int id)
        {
            await _OrderRepository.SoftDeleteOrderAsync(id);
        }
    }
}
