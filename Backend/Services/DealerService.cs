using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IDealerService
    {
        Task<IEnumerable<Dealer>> GetAllDealerAsync();
        Task<Dealer?> GetDealerByIdAsync(int id);
        Task CreateDealerAsync(Dealer dealer);
        Task UpdateDealerAsync(Dealer dealer);
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
        public async Task CreateDealerAsync(Dealer dealer)
        {
            await _DealerRepository.CreateDealerAsync(dealer);
        }
        public async Task UpdateDealerAsync(Dealer dealer)
        {
            await _DealerRepository.UpdateDealerAsync(dealer);
        }
        public async Task SoftDeleteDealerAsync(int id)
        {
            await _DealerRepository.SoftDeleteDealerAsync(id);
        }
    }
}
