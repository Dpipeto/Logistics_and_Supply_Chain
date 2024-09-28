using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync();
        Task<OrderDetail?> GetOrderDetailByIdAsync(int id);
        Task CreateOrderDetailAsync(OrderDetail orderDetail);
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
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
        public async Task CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            await _OrderDetailRepository.CreateOrderDetailAsync(orderDetail);
        }
        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            await _OrderDetailRepository.UpdateOrderDetailAsync(orderDetail);
        }
        public async Task SoftDeleteOrderDetailAsync(int id)
        {
            await _OrderDetailRepository.SoftDeleteOrderDetailAsync(id);
        }
    }
}
