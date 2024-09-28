using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _UserRepository.GetAllUserAsync();
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _UserRepository.GetUserByIdAsync(id);
        }
        public async Task CreateUserAsync(User user)
        {
            await _UserRepository.CreateUserAsync(user);
        }
        public async Task UpdateUserAsync(User user)
        {
            await _UserRepository.UpdateUserAsync(user);
        }
        public async Task SoftDeleteUserAsync(int id)
        {
            await _UserRepository.SoftDeleteUserAsync(id);
        }
    }
}
