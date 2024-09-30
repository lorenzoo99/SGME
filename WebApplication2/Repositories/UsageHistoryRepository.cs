using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;

namespace SGME.Repositories
{
    public interface IUsageHistoryRepository
    {
        Task<IEnumerable<UsageHistory>> GetAllUsageHistoriesAsync();
        Task<UsageHistory> GetUsageHistoryByIdAsync(int id);
        Task CreateUsageHistoryAsync(UsageHistory usageHistory);
        Task UpdateUsageHistoryAsync(UsageHistory usageHistory);
        Task DeleteUsageHistoryAsync(int id);
    }

    public class UsageHistoryRepository : IUsageHistoryRepository
    {
        private readonly TestContext _context;

        public UsageHistoryRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsageHistory>> GetAllUsageHistoriesAsync()
        {
            return await _context.UsageHistorys
                .Where(uh => !uh.IsDeleted) // Excluye los eliminados
                .ToListAsync();
        }

        public async Task<UsageHistory> GetUsageHistoryByIdAsync(int id)
        {
            return await _context.UsageHistorys
                .FirstOrDefaultAsync(uh => uh.UsageHistoryId == id && !uh.IsDeleted);
        }

        public async Task CreateUsageHistoryAsync(UsageHistory usageHistory)
        {
            try
            {
                await _context.UsageHistorys.AddAsync(usageHistory);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw; // Manejo de excepción opcional
            }
        }

        public async Task UpdateUsageHistoryAsync(UsageHistory usageHistory)
        {
            _context.UsageHistorys.Update(usageHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsageHistoryAsync(int id)
        {
            var usageHistory = await _context.UsageHistorys.FindAsync(id);
            if (usageHistory != null)
            {
                usageHistory.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
        }
    }
}
