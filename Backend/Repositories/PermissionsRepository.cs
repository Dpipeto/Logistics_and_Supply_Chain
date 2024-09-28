using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace Backend.Repositories
{
    public interface IPermissionsRepository
    {
        Task<IEnumerable<Permissions>> GetAllPermissionsAsync();
        Task<Permissions?> GetPermissionsByIdAsync(int id);
        Task CreatePermissionsAsync(Permissions permissions);
        Task UpdatePermissionsAsync(Permissions permissions);
        Task SoftDeletePermissionsAsync(int id);
    }
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly DeliveryDbContext _context;

        public PermissionsRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Permissions>> GetAllPermissionsAsync()
        {
            return await _context.permissions
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<Permissions>> GetPermissionsAsync()
        {
            return await _context.permissions
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<Permissions?> GetPermissionsByIdAsync(int id)
        {
            return await _context.permissions
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreatePermissionsAsync(Permissions permissions)
        {
            _context.permissions.Add(permissions);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePermissionsAsync(Permissions permissions)
        {
            _context.permissions.Update(permissions);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeletePermissionsAsync(int id)
        {
            var permissions = await _context.permissions.FindAsync(id);
            if (permissions != null)
            {
                permissions.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
