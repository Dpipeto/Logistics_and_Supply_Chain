using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly DeliveryDbContext _context;

        public UserRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.users
               .Where(s => !s.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _context.users
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.users
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreateUserAsync(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(User user)
        {
            _context.users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
