using Backend.Context;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace Backend.Repositories
{
    public interface IDealerRepository
    {
        Task<IEnumerable<Dealer>> GetAllDealerAsync();
        Task<Dealer?> GetDealerByIdAsync(int id);
        Task CreateDealerAsync(string orderDate, string deliveryDate, int userId);
        Task UpdateDealerAsync(int id, string orderDate, string deliveryDate, int userId);
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
        public async Task CreateDealerAsync(string orderDate, string deliveryDate, int userId)
        {
            var user = await _context.users.FindAsync(userId) ?? throw new Exception("user not found");

            var dealer = new Dealer
            {
                OrderDate = orderDate,
                DeliveryDate = deliveryDate,
                User = user,
            };
            await _context.dealers.AddAsync(dealer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDealerAsync(int id, string orderDate, string deliveryDate, int userId)
        {
            var dealer = await _context.dealers.FindAsync(id) ?? throw new Exception("Dealer not found");

            var user = await _context.users.FindAsync(userId) ?? throw new Exception("user not found");

            dealer.OrderDate = orderDate;
            dealer.DeliveryDate = deliveryDate;
            dealer.User = user;
            try
            {
                _context.dealers.Update(dealer);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
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