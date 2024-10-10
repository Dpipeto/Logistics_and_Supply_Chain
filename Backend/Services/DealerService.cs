using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IDealerService
    {
        Task<IEnumerable<Dealer>> GetAllDealerAsync();
        Task<Dealer?> GetDealerByIdAsync(int id);
        Task CreateDealerAsync(string orderDate, string deliveryDate, int userId);
        Task UpdateDealerAsync(int id, string orderDate, string deliveryDate, int userId);
        Task SoftDeleteDealerAsync(int id);
    }
    public class DealerService : IDealerService
    {
        private readonly IDealerRepository _DealerRepository;

        public DealerService(IDealerRepository DealerRepository)
        {
            _DealerRepository = DealerRepository;
        }
        public async Task<IEnumerable<Dealer>> GetAllDealerAsync()
        {
            return await _DealerRepository.GetAllDealerAsync();
        }
        public async Task<Dealer?> GetDealerByIdAsync(int id)
        {
            return await _DealerRepository.GetDealerByIdAsync(id);
        }
        public async Task CreateDealerAsync(string orderDate, string deliveryDate, int userId)
        {
            await _DealerRepository.CreateDealerAsync(orderDate, deliveryDate, userId);
        }
        public async Task UpdateDealerAsync(int id, string orderDate, string deliveryDate, int userId)
        {
            await _DealerRepository.UpdateDealerAsync(id, orderDate, deliveryDate, userId);
        }
        public async Task SoftDeleteDealerAsync(int id)
        {
            await _DealerRepository.SoftDeleteDealerAsync(id);
        }
    }
}
