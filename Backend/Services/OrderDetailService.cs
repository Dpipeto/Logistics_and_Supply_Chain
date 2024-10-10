using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync();
        Task<OrderDetail?> GetOrderDetailByIdAsync(int id);
        Task CreateOrderDetailAsync(string deliveryTime);
        Task UpdateOrderDetailAsync(int id, string deliveryTime);
        Task SoftDeleteOrderDetailAsync(int id);
    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _OrderDetailRepository;

        public OrderDetailService(IOrderDetailRepository OrderDetailRepository)
        {
            _OrderDetailRepository = OrderDetailRepository;
        }
        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync()
        {
            return await _OrderDetailRepository.GetAllOrderDetailAsync();
        }
        public async Task<OrderDetail?> GetOrderDetailByIdAsync(int id)
        {
            return await _OrderDetailRepository.GetOrderDetailByIdAsync(id);
        }
        public async Task CreateOrderDetailAsync(string deliveryTime)
        {
            await _OrderDetailRepository.CreateOrderDetailAsync(deliveryTime);
        }
        public async Task UpdateOrderDetailAsync(int id, string deliveryTime)
        {
            await _OrderDetailRepository.UpdateOrderDetailAsync(id, deliveryTime);
        }
        public async Task SoftDeleteOrderDetailAsync(int id)
        {
            await _OrderDetailRepository.SoftDeleteOrderDetailAsync(id);
        }
    }
}
