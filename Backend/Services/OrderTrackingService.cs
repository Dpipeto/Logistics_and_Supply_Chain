using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IOrderTrackingService
    {
        Task<IEnumerable<OrderTracking>> GetAllOrderTrackingAsync();
        Task<OrderTracking?> GetOrderTrackingByIdAsync(int id);
        Task CreateOrderTrackingAsync(string date, int orderId, int dealerId);
        Task UpdateOrderTrackingAsync(int id, string date, int orderId, int dealerId);
        Task SoftDeleteOrderTrackingAsync(int id);
    }
    public class OrderTrackingService : IOrderTrackingService
    {
        private readonly IOrderTrackingRepository _OrderTrackingRepository;

        public OrderTrackingService(IOrderTrackingRepository OrderTrackingRepository)
        {
            _OrderTrackingRepository = OrderTrackingRepository;
        }
        public async Task<IEnumerable<OrderTracking>> GetAllOrderTrackingAsync()
        {
            return await _OrderTrackingRepository.GetAllOrderTrackingAsync();
        }
        public async Task<OrderTracking?> GetOrderTrackingByIdAsync(int id)
        {
            return await _OrderTrackingRepository.GetOrderTrackingByIdAsync(id);
        }
        public async Task CreateOrderTrackingAsync(string date, int orderId, int dealerId)
        {
            await _OrderTrackingRepository.CreateOrderTrackingAsync(date, orderId, dealerId);
        }
        public async Task UpdateOrderTrackingAsync(int id, string date, int orderId, int dealerId)
        {
            await _OrderTrackingRepository.UpdateOrderTrackingAsync(id, date, orderId, dealerId);
        }
        public async Task SoftDeleteOrderTrackingAsync(int id)
        {
            await _OrderTrackingRepository.SoftDeleteOrderTrackingAsync(id);
        }
    }
}
