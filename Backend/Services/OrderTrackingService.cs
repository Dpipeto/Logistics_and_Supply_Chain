using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IOrderTrackingService
    {
        Task<IEnumerable<OrderTracking>> GetAllOrderTrackingAsync();
        Task<OrderTracking?> GetOrderTrackingByIdAsync(int id);
        Task CreateOrderTrackingAsync(OrderTracking orderTracking);
        Task UpdateOrderTrackingAsync(OrderTracking orderTracking);
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
        public async Task CreateOrderTrackingAsync(OrderTracking orderTracking)
        {
            await _OrderTrackingRepository.CreateOrderTrackingAsync(orderTracking);
        }
        public async Task UpdateOrderTrackingAsync(OrderTracking orderTracking)
        {
            await _OrderTrackingRepository.UpdateOrderTrackingAsync(orderTracking);
        }
        public async Task SoftDeleteOrderTrackingAsync(int id)
        {
            await _OrderTrackingRepository.SoftDeleteOrderTrackingAsync(id);
        }
    }
}
