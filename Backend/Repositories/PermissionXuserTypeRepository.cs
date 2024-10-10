using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IPermissionXuserTypeRepository
    {
        Task<IEnumerable<PermissionXuserType>> GetAllPermissionXuserTypeAsync();
        Task<PermissionXuserType?> GetPermissionXuserTypeByIdAsync(int id);
        Task CreatePermissionXuserTypeAsync(int userTypesId, int permissionsId);
        Task UpdatePermissionXuserTypeAsync(int id, int userTypesId, int permissionsId);
        Task SoftDeletePermissionXuserTypeAsync(int id);
        Task<bool> HasPermissionAsync(int userTypeId, int permissionId);
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
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .Include(p => p.UserTypes)
                .Include(p => p.Permissions)
                .ToListAsync();
        }
        public async Task<PermissionXuserType?> GetPermissionXuserTypeByIdAsync(int id)
        {
            return await _context.permissionsXuser.AsNoTracking()
                .Include(p => p.UserTypes)
                .Include(p => p.Permissions)
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreatePermissionXuserTypeAsync(int userTypesId, int permissionsId)
        {
            // Fetch foreing keys if exists
            var userType = await _context.usersTypes.FindAsync(userTypesId) ?? throw new Exception("UserType not found");
            var permission = await _context.permissions.FindAsync(permissionsId) ?? throw new Exception("Permission not found");

            var permissionUserType = new PermissionXuserType
            {
                Permissions = permission,
                UserTypes = userType
            };

            await _context.permissionsXuser.AddAsync(permissionUserType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePermissionXuserTypeAsync(int id, int userTypesId, int permissionsId)
        {
            var permissionUserType = await _context.permissionsXuser.FindAsync(id) ?? throw new Exception("PermissionUserType not found");

            // Fetch foreing keys if exists
            var userType = await _context.usersTypes.FindAsync(userTypesId) ?? throw new Exception("UserType not found");
            var permission = await _context.permissions.FindAsync(permissionsId) ?? throw new Exception("UserType not found");

            permissionUserType.Permissions = permission;
            permissionUserType.UserTypes = userType;


            try
            {
                _context.permissionsXuser.Update(permissionUserType);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw;

            }
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
        public async Task<bool> HasPermissionAsync(int userTypeId, int permissionId)
        {
            var permission = await _context.permissionsXuser
            .Where(p => p.UserTypes.Id == userTypeId && p.Permissions.Id == permissionId && !p.IsDeleted)
            .FirstOrDefaultAsync();

            return permission != null ? true : false;
        }
    }
}
