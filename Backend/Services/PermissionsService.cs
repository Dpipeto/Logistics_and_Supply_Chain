using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IPermissionsService
    {
        Task<IEnumerable<Permissions>> GetAllPermissionsAsync();
        Task<Permissions?> GetPermissionsByIdAsync(int id);
        Task CreatePermissionsAsync(string permission);
        Task UpdatePermissionsAsync(int id, string permission);
        Task SoftDeletePermissionsAsync(int id);
    }
    public class PermissionsService : IPermissionsService
    {
        private readonly IPermissionsRepository _PermissionsRepository;

        public PermissionsService(IPermissionsRepository PermissionsRepository)
        {
            _PermissionsRepository = PermissionsRepository;
        }
        public async Task<IEnumerable<Permissions>> GetAllPermissionsAsync()
        {
            return await _PermissionsRepository.GetAllPermissionsAsync();
        }
        public async Task<Permissions?> GetPermissionsByIdAsync(int id)
        {
            return await _PermissionsRepository.GetPermissionsByIdAsync(id);
        }
        public async Task CreatePermissionsAsync(string permission)
        {
            await _PermissionsRepository.CreatePermissionsAsync(permission);
        }
        public async Task UpdatePermissionsAsync(int id, string permission)
        {
            await _PermissionsRepository.UpdatePermissionsAsync(id, permission);
        }
        public async Task SoftDeletePermissionsAsync(int id)
        {
            await _PermissionsRepository.SoftDeletePermissionsAsync(id);
        }
    }
}
