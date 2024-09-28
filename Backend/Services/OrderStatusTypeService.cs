using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IOrderStatusTypeService
    {
        Task<IEnumerable<OrderStatusType>> GetAllOrderStatusTypeAsync();
        Task<OrderStatusType?> GetOrderStatusTypeByIdAsync(int id);
        Task CreateOrderStatusTypeAsync(OrderStatusType orderStatusType);
        Task UpdateOrderStatusTypeAsync(OrderStatusType orderStatusType);
        Task SoftDeleteOrderStatusTypeAsync(int id);
    }
    public class OrderStatusTypeService : IOrderStatusTypeService
    {
        private readonly IOrderStatusTypeRepository _OrderStatusTypeRepository;

        public OrderStatusTypeService(IOrderStatusTypeRepository OrderStatusTypeRepository)
        {
            _OrderStatusTypeRepository = OrderStatusTypeRepository;
        }
        public async Task<IEnumerable<OrderStatusType>> GetAllOrderStatusTypeAsync()
        {
            return await _OrderStatusTypeRepository.GetAllOrderStatusTypeAsync();
        }
        public async Task<OrderStatusType?> GetOrderStatusTypeByIdAsync(int id)
        {
            return await _OrderStatusTypeRepository.GetOrderStatusTypeByIdAsync(id);
        }
        public async Task CreateOrderStatusTypeAsync(OrderStatusType orderStatus)
        {
            await _OrderStatusTypeRepository.CreateOrderStatusTypeAsync(orderStatus);
        }
        public async Task UpdateOrderStatusTypeAsync(OrderStatusType orderStatus)
        {
            await _OrderStatusTypeRepository.UpdateOrderStatusTypeAsync(orderStatus);
        }
        public async Task SoftDeleteOrderStatusTypeAsync(int id)
        {
            await _OrderStatusTypeRepository.SoftDeleteOrderStatusTypeAsync(id);
        }
    }
}
