using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IPermissionXuserTypeService
    {
        Task<IEnumerable<PermissionXuserType>> GetAllPermissionXuserTypeAsync();
        Task<PermissionXuserType?> GetPermissionXuserTypeByIdAsync(int id);
        Task CreatePermissionXuserTypeAsync(PermissionXuserType permissionXuserType);
        Task UpdatePermissionXuserTypeAsync(PermissionXuserType permissionXuserType);
        Task SoftDeletePermissionXuserTypeAsync(int id);
    }
    public class PermissionXuserTypeService : IPermissionXuserTypeService
    {
        private readonly IPermissionXuserTypeRepository _PermissionXuserTypeRepository;

        public PermissionXuserTypeService(IPermissionXuserTypeRepository PermissionXuserTypeRepository)
        {
            _PermissionXuserTypeRepository = PermissionXuserTypeRepository;
        }
        public async Task<IEnumerable<PermissionXuserType>> GetAllPermissionXuserTypeAsync()
        {
            return await _PermissionXuserTypeRepository.GetAllPermissionXuserTypeAsync();
        }
        public async Task<PermissionXuserType?> GetPermissionXuserTypeByIdAsync(int id)
        {
            return await _PermissionXuserTypeRepository.GetPermissionXuserTypeByIdAsync(id);
        }
        public async Task CreatePermissionXuserTypeAsync(PermissionXuserType permissionXuserType)
        {
            await _PermissionXuserTypeRepository.CreatePermissionXuserTypeAsync(permissionXuserType);
        }
        public async Task UpdatePermissionXuserTypeAsync(PermissionXuserType permissionXuserType)
        {
            await _PermissionXuserTypeRepository.UpdatePermissionXuserTypeAsync(permissionXuserType);
        }
        public async Task SoftDeletePermissionXuserTypeAsync(int id)
        {
            await _PermissionXuserTypeRepository.SoftDeletePermissionXuserTypeAsync(id);
        }
    }
}
