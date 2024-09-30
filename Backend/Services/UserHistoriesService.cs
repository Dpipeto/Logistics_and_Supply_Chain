using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IUserHistoriesService
    {
        Task<IEnumerable<UserHistories>> GetAllUserHistoriesAsync();
        Task<UserHistories> GetUserHistoryByIdAsync(int id);
        Task CreateUserHistoryAsync(UserHistories userHistory);
        Task UpdateUserHistoryAsync(UserHistories userHistory);
        Task SoftDeleteUserHistoryAsync(int id);
    }

    public class UserHistoriesService : IUserHistoriesService
    {
        private readonly IUserHistoriesRepository _userHistoriesRepository;

        public UserHistoriesService(IUserHistoriesRepository userHistoriesRepository)
        {
            _userHistoriesRepository = userHistoriesRepository;
        }

        public async Task<IEnumerable<UserHistories>> GetAllUserHistoriesAsync()
        {
            return await _userHistoriesRepository.GetAllUserHistoriesAsync();
        }

        public async Task<UserHistories> GetUserHistoryByIdAsync(int id)
        {
            return await _userHistoriesRepository.GetUserHistoryByIdAsync(id);
        }

        public async Task CreateUserHistoryAsync(UserHistories userHistory)
        {
            await _userHistoriesRepository.CreateUserHistoryAsync(userHistory);
        }

        public async Task UpdateUserHistoryAsync(UserHistories userHistory)
        {
            await _userHistoriesRepository.UpdateUserHistoryAsync(userHistory);
        }

        public async Task SoftDeleteUserHistoryAsync(int id)
        {
            await _userHistoriesRepository.SoftDeleteUserHistoryAsync(id);
        }
    }

}
