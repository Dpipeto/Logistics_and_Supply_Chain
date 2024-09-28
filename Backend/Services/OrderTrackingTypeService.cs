using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IOrderTrackingTypeService
    {
        Task<IEnumerable<OrderTrackingType>> GetAllOrderTrackingTypeAsync();
        Task<OrderTrackingType?> GetOrderTrackingTypeByIdAsync(int id);
        Task CreateOrderTrackingTypeAsync(OrderTrackingType orderTrackingType);
        Task UpdateOrderTrackingTypeAsync(OrderTrackingType orderTrackingType);
        Task SoftDeleteOrderTrackingTypeAsync(int id);
    }
    public class OrderTrackingTypeService : IOrderTrackingTypeService
    {
        private readonly IOrderTrackingTypeRepository _OrderTrackingTypeRepository;

        public OrderTrackingTypeService(IOrderTrackingTypeRepository OrderTrackingTypeRepository)
        {
            _OrderTrackingTypeRepository = OrderTrackingTypeRepository;
        }
        public async Task<IEnumerable<OrderTrackingType>> GetAllOrderTrackingTypeAsync()
        {
            return await _OrderTrackingTypeRepository.GetAllOrderTrackingTypeAsync();
        }
        public async Task<OrderTrackingType?> GetOrderTrackingTypeByIdAsync(int id)
        {
            return await _OrderTrackingTypeRepository.GetOrderTrackingTypeByIdAsync(id);
        }
        public async Task CreateOrderTrackingTypeAsync(OrderTrackingType orderTrackingType)
        {
            await _OrderTrackingTypeRepository.CreateOrderTrackingTypeAsync(orderTrackingType);
        }
        public async Task UpdateOrderTrackingTypeAsync(OrderTrackingType orderTrackingType)
        {
            await _OrderTrackingTypeRepository.UpdateOrderTrackingTypeAsync(orderTrackingType);
        }
        public async Task SoftDeleteOrderTrackingTypeAsync(int id)
        {
            await _OrderTrackingTypeRepository.SoftDeleteOrderTrackingTypeAsync(id);
        }
    }
}
