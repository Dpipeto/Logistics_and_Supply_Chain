using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IOrderDetailHistoriesService
    {
        Task<IEnumerable<OrderDetailHistories>> GetAllOrderDetailHistoriesAsync();
        Task<OrderDetailHistories?> GetOrderDetailHistoriesByIdAsync(int id);
        Task CreateOrderDetailHistoriesAsync(OrderDetailHistories orderDetailHistories);
        Task UpdateOrderDetailHistoriesAsync(OrderDetailHistories orderDetailHistories);
        Task SoftDeleteOrderDetailHistoriesAsync(int id);
    }
    public class OrderDetailHistoriesService : IOrderDetailHistoriesService
    {
        private readonly IOrderDetailHistoriesRepository _OrderDetailHistoriesRepository;

        public OrderDetailHistoriesService(IOrderDetailHistoriesRepository OrderDetailHistoriesRepository)
        {
            _OrderDetailHistoriesRepository = OrderDetailHistoriesRepository;
        }
        public async Task<IEnumerable<OrderDetailHistories>> GetAllOrderDetailHistoriesAsync()
        {
            return await _OrderDetailHistoriesRepository.GetAllOrderDetailHistoriesAsync();
        }
        public async Task<OrderDetailHistories?> GetOrderDetailHistoriesByIdAsync(int id)
        {
            return await _OrderDetailHistoriesRepository.GetOrderDetailHistoriesByIdAsync(id);
        }
        public async Task CreateOrderDetailHistoriesAsync(OrderDetailHistories orderDetailHistories)
        {
            await _OrderDetailHistoriesRepository.CreateOrderDetailHistoriesAsync(orderDetailHistories);
        }
        public async Task UpdateOrderDetailHistoriesAsync(OrderDetailHistories orderDetailHistories)
        {
            await _OrderDetailHistoriesRepository.UpdateOrderDetailHistoriesAsync(orderDetailHistories);
        }
        public async Task SoftDeleteOrderDetailHistoriesAsync(int id)
        {
            await _OrderDetailHistoriesRepository.SoftDeleteOrderDetailHistoriesAsync(id);
        }
    }
}
