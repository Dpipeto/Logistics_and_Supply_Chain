using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserTypes>> GetAllUserTypesAsync();
        Task<UserTypes?> GetUserTypesByIdAsync(int id);
        Task CreateUserTypesAsync(string usertype);
        Task UpdateUserTypesAsync(int id, string usertype);
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
        public async Task CreateUserTypesAsync(string usertype)
        {
            var userTypes = new UserTypes
            {
                UserType = usertype,
            };

            _context.usersTypes.Add(userTypes);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserTypesAsync(int id, string usertype)
        {
            var userTypes = await _context.usersTypes.FindAsync(id) ?? throw new Exception("User Type not found");

            userTypes.UserType = usertype;

            try
            {
                _context.usersTypes.Update(userTypes);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task SoftDeleteUserTypesAsync(int id)
        {
            var userTypes = await _context.usersTypes.FindAsync(id);
            if (userTypes != null)
            {
                userTypes.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
