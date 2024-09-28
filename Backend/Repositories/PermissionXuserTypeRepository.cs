using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IPermissionXuserTypeRepository
    {
        Task<IEnumerable<PermissionXuserType>> GetAllPermissionXuserTypeAsync();
        Task<PermissionXuserType?> GetPermissionXuserTypeByIdAsync(int id);
        Task CreatePermissionXuserTypeAsync(PermissionXuserType permissionXuserType);
        Task UpdatePermissionXuserTypeAsync(PermissionXuserType permissionXuserType);
        Task SoftDeletePermissionXuserTypeAsync(int id);
    }
    public class PermissionXuserTypeRepository : IPermissionXuserTypeRepository
    {
        private readonly DeliveryDbContext _context;

        public PermissionXuserTypeRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PermissionXuserType>> GetAllPermissionXuserTypeAsync()
        {
            return await _context.permissionsXuser
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<PermissionXuserType>> GetPermissionXuserTypeAsync()
        {
            return await _context.permissionsXuser
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<PermissionXuserType?> GetPermissionXuserTypeByIdAsync(int id)
        {
            return await _context.permissionsXuser
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreatePermissionXuserTypeAsync(PermissionXuserType permissionXuserType)
        {
            _context.permissionsXuser.Add(permissionXuserType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePermissionXuserTypeAsync(PermissionXuserType permissionXuserType)
        {
            _context.permissionsXuser.Update(permissionXuserType);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeletePermissionXuserTypeAsync(int id)
        {
            var permissionsXuserType = await _context.permissionsXuser.FindAsync(id);
            if (permissionsXuserType != null)
            {
                permissionsXuserType.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
