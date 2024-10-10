using Backend.Model;
using Backend.Repositories;

namespace Backend.Services
{
    public interface IPermissionXuserTypeService
    {
        Task<IEnumerable<PermissionXuserType>> GetAllPermissionXuserTypeAsync();
        Task<PermissionXuserType?> GetPermissionXuserTypeByIdAsync(int id);
        Task CreatePermissionXuserTypeAsync(int userTypesId, int permissionsId);
        Task UpdatePermissionXuserTypeAsync(int id, int userTypesId, int permissionsId);
        Task SoftDeletePermissionXuserTypeAsync(int id);
        Task<bool> HasPermissionAsync(int userTypesId, int permissionsId);
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
        public async Task CreatePermissionXuserTypeAsync(int userTypesId, int permissionsId)
        {
            await _PermissionXuserTypeRepository.CreatePermissionXuserTypeAsync(userTypesId, permissionsId);
        }
        public async Task UpdatePermissionXuserTypeAsync(int id, int userTypesId, int permissionsId)
        {
            try
            {
                await _PermissionXuserTypeRepository.UpdatePermissionXuserTypeAsync(id, userTypesId, permissionsId);

            }
            catch (Exception e)
            {

                throw;

            }
        }
        public async Task SoftDeletePermissionXuserTypeAsync(int id)
        {
            await _PermissionXuserTypeRepository.SoftDeletePermissionXuserTypeAsync(id);
        }
        public async Task<bool> HasPermissionAsync(int userTypesId, int permissionsId)
        {
            try
            {
                return await _PermissionXuserTypeRepository.HasPermissionAsync(userTypesId, permissionsId);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
