using Backend.Model;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserTypes>> GetAllUserTypesAsync();
        Task<UserTypes?> GetUserTypesByIdAsync(int id);
        Task CreateUserTypesAsync(UserTypes user_Types);
        Task UpdateUserTypesAsync(UserTypes user_Types);
        Task SoftDeleteUserTypesAsync(int id);
    }
    public class UserTypeService :IUserTypeService
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
        public async Task CreateUserTypesAsync(UserTypes user_Types)
        {
            await _userTypeRepository.CreateUserTypesAsync(user_Types);
        }
        public async Task UpdateUserTypesAsync(UserTypes user_Types)
        {
            await _userTypeRepository.UpdateUserTypesAsync(user_Types);
        }
        public async Task SoftDeleteUserTypesAsync(int id)
        {
            await _userTypeRepository.SoftDeleteUserTypesAsync(id);
        }
    }
}
                                                    