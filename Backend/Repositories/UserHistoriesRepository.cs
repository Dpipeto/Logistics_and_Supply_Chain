using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IUserHistoriesRepository
    {
        Task<IEnumerable<UserHistories>> GetAllUserHistoriesAsync();
        Task<UserHistories> GetUserHistoryByIdAsync(int id);
        Task CreateUserHistoryAsync(UserHistories userHistory);
        Task UpdateUserHistoryAsync(UserHistories userHistory);
        Task SoftDeleteUserHistoryAsync(int id);
    }

    public class UserHistoriesRepository : IUserHistoriesRepository
    {
        private readonly DeliveryDbContext _context;

        public UserHistoriesRepository(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserHistories>> GetAllUserHistoriesAsync()
        {
            return await _context.UserHistories
                .Where(uh => !uh.IsDeleted)
                .ToListAsync();
        }

        public async Task<UserHistories> GetUserHistoryByIdAsync(int id)
        {
            return await _context.UserHistories
                .FirstOrDefaultAsync(uh => uh.Id == id && !uh.IsDeleted);
        }

        public async Task CreateUserHistoryAsync(UserHistories userHistory)
        {
            _context.UserHistories.Add(userHistory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserHistoryAsync(UserHistories userHistory)
        {
            _context.UserHistories.Update(userHistory);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteUserHistoryAsync(int id)
        {
            var userHistory = await _context.UserHistories.FindAsync(id);
            if (userHistory != null)
            {
                userHistory.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }

}


