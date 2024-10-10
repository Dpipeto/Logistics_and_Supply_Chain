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
        Task CreatePermissionsAsync(string permission);
        Task UpdatePermissionsAsync(int id, string permission);
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
        public async Task CreatePermissionsAsync(string permission)
        {
            var permissions = new Permissions
            {
                Permission = permission
            };

            _context.permissions.Add(permissions);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePermissionsAsync(int id, string permission)
        {
            var permissions = await _context.permissions.FindAsync(id) ?? throw new Exception("Permissions not found");

            permissions.Permission = permission;
            try
            {
                _context.permissions.Update(permissions);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
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
