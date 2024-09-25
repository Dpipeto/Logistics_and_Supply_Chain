using Backend.Model;
using Backend.Repositories;
using Backend.Repository;

namespace Backend.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
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
        public async Task CreateOrderAsync(Order order)
        {
            await _OrderRepository.CreateOrderAsync(order);
        }
        public async Task UpdateOrderAsync(Order order)
        {
            await _OrderRepository.UpdateOrderAsync(order);
        }
        public async Task SoftDeleteOrderAsync(int id)
        {
            await _OrderRepository.SoftDeleteOrderAsync(id);
        }
    }
}
