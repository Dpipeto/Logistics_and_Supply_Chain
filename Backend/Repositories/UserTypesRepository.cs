using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserTypes>> GetAllUserTypesAsync();
        Task<UserTypes?> GetUserTypesByIdAsync(int id);
        Task CreateUserTypesAsync(UserTypes user_Types);
        Task UpdateUserTypesAsync(UserTypes user_Types);
        Task SoftDeleteUserTypesAsync(int id);
    }
    public class UserTypesRepository : IUserTypeRepository
    {
        private readonly DeliveryDbContext _context;

        public UserTypesRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserTypes>> GetAllUserTypesAsync()
        {
            return await _context.usersTypes
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<UserTypes>> GetUserTypesAsync()
        {
            return await _context.usersTypes
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<UserTypes?> GetUserTypesByIdAsync(int id)
        {
            return await _context.usersTypes
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreateUserTypesAsync(UserTypes user_Types)
        {
            _context.usersTypes.Add(user_Types);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteUserTypesAsync(int id)
        {
            var user_Types = await _context.usersTypes.FindAsync(id);
            if (user_Types != null)
            {
                user_Types.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserTypesAsync(UserTypes user)
        {
            _context.usersTypes.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
