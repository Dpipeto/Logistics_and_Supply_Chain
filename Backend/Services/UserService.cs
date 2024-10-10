using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task CreateUserAsync(string first_Name, string last_Name, string username, string email, string password, string address, string phone, string iD_Document, string date, int userTypesId);
        Task UpdateUserAsync(int id, string first_Name, string last_Name, string username, string email, string password, string address, string phone, string iD_Document, string date, int userTypesId);
        Task SoftDeleteUserAsync(int id);
        Task<bool> ValidateUserAsync(string email, string password);
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
        public async Task CreateUserAsync(string first_Name, string last_Name, string username, string email, string password, string address, string phone, string iD_Document, string date, int userTypesId)
        {
            await _UserRepository.CreateUserAsync(first_Name, last_Name, username, email, password, address, phone, iD_Document, date, userTypesId);
        }
        public async Task UpdateUserAsync(int id, string first_Name, string last_Name, string username, string email, string password, string address, string phone, string iD_Document, string date, int userTypesId)
        {
            try
            {
                await _UserRepository.UpdateUserAsync(id, first_Name, last_Name, username, email, password, address, phone, iD_Document, date, userTypesId);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task SoftDeleteUserAsync(int id)
        {
            await _UserRepository.SoftDeleteUserAsync(id);
        }
        // validate user
        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            try
            {
                return await _UserRepository.ValidateUserAsync(email, password);
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
