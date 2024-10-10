using Backend.Model;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserTypes>> GetAllUserTypesAsync();
        Task<UserTypes?> GetUserTypesByIdAsync(int id);
        Task CreateUserTypesAsync(string usertype);
        Task UpdateUserTypesAsync(int id, string usertype);
        Task SoftDeleteUserTypesAsync(int id);
    }
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }
        public async Task<IEnumerable<UserTypes>> GetAllUserTypesAsync()
        {
            return await _userTypeRepository.GetAllUserTypesAsync();
        }
        public async Task<UserTypes?> GetUserTypesByIdAsync(int id)
        {
            return await _userTypeRepository.GetUserTypesByIdAsync(id);
        }
        public async Task CreateUserTypesAsync(string usertype)
        {
            await _userTypeRepository.CreateUserTypesAsync(usertype);
        }
        public async Task UpdateUserTypesAsync(int id, string usertype)
        {
            await _userTypeRepository.UpdateUserTypesAsync(id, usertype);
        }
        public async Task SoftDeleteUserTypesAsync(int id)
        {
            await _userTypeRepository.SoftDeleteUserTypesAsync(id);
        }
    }
}
                                                    