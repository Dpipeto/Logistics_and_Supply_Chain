using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IPermissionsService
    {
        Task<IEnumerable<Permissions>> GetAllPermissionsAsync();
        Task<Permissions?> GetPermissionsByIdAsync(int id);
        Task CreatePermissionsAsync(Permissions permissions);
        Task UpdatePermissionsAsync(Permissions permissions);
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
        public async Task CreatePermissionsAsync(Permissions permissions)
        {
            await _PermissionsRepository.CreatePermissionsAsync(permissions);
        }
        public async Task UpdatePermissionsAsync(Permissions permissions)
        {
            await _PermissionsRepository.UpdatePermissionsAsync(permissions);
        }
        public async Task SoftDeletePermissionsAsync(int id)
        {
            await _PermissionsRepository.SoftDeletePermissionsAsync(id);
        }
    }
}
