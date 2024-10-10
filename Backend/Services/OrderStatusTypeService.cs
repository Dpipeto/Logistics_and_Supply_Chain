using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IOrderStatusTypeService
    {
        Task<IEnumerable<OrderStatusType>> GetAllOrderStatusTypeAsync();
        Task<OrderStatusType?> GetOrderStatusTypeByIdAsync(int id);
        Task CreateOrderStatusTypeAsync(string orderStatusType);
        Task UpdateOrderStatusTypeAsync(int id, string orderStatusType);
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
        public async Task CreateOrderStatusTypeAsync(string orderStatusType)
        {
            await _OrderStatusTypeRepository.CreateOrderStatusTypeAsync(orderStatusType);
        }
        public async Task UpdateOrderStatusTypeAsync(int id, string orderStatusType)
        {
            await _OrderStatusTypeRepository.UpdateOrderStatusTypeAsync(id, orderStatusType);
        }
        public async Task SoftDeleteOrderStatusTypeAsync(int id)
        {
            await _OrderStatusTypeRepository.SoftDeleteOrderStatusTypeAsync(id);
        }
    }
}
