using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Backend.Repositories
{
    public interface IDealerRepository
    {
        Task<IEnumerable<Dealer>> GetAllDealerAsync();
        Task<Dealer?> GetDealerByIdAsync(int id);
        Task CreateDealerAsync(Dealer dealer);
        Task UpdateDealerAsync(Dealer dealer);
        Task SoftDeleteDealerAsync(int id);
    }
    public class DealerRepository : IDealerRepository
    {
        private readonly DeliveryDbContext _context;

        public DealerRepository(DeliveryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Dealer>> GetAllDealerAsync()
        {
            try
            {
                IEnumerable<Dealer> del = await _context.dealers
                                                              .Where(s => !s.IsDeleted)
                                                              .ToListAsync();
                return del;
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<IEnumerable<Dealer>> GetDealerAsync()
        {
            return await _context.dealers
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<Dealer?> GetDealerByIdAsync(int id)
        {
            return await _context.dealers
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }
        public async Task CreateDealerAsync(Dealer dealer)
        {
            _context.dealers.Add(dealer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDealerAsync(Dealer dealer)
        {
            _context.dealers.Update(dealer);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteDealerAsync(int id)
        {
            var dealer = await _context.dealers.FindAsync(id);
            if (dealer != null)
            {
                dealer.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}