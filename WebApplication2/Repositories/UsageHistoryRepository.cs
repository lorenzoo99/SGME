using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;

namespace SGME.Repositories
{
    public interface IUsageHistoryRepository
    {
        Task<IEnumerable<UsageHistory>> GetAllUsageHistoriesAsync();
        Task<UsageHistory> GetUsageHistoryByIdAsync(int UsageHistoryId);
        Task CreateUsageHistoryAsync(int ViewDuration, UsageHistory usageHistory);
        Task UpdateUsageHistoryAsync(int UsageHistoryId, int ViewDuration, UsageHistory usageHistory);
        Task DeleteUsageHistoryAsync(int UsageHistoryId);
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
            return await _context.UsageHistories
                .Where(uh => !uh.IsDeleted) // Excluye los eliminados
                .ToListAsync();
        }

        public async Task<UsageHistory> GetUsageHistoryByIdAsync(int UsageHistoryId)
        {
            return await _context.UsageHistories
                .FirstOrDefaultAsync(uh => uh.UsageHistoryId == UsageHistoryId && !uh.IsDeleted);
        }

        public async Task CreateUsageHistoryAsync(int ViewDuration, UsageHistory usageHistory)
        {
            try
            {
                await _context.UsageHistories.AddAsync(usageHistory);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw; // Manejo de excepción opcional
            }
        }

        public async Task UpdateUsageHistoryAsync(int UsageHistoryId, int ViewDuration, UsageHistory usageHistory)
        {
            _context.UsageHistories.Update(usageHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsageHistoryAsync(int UsageHistoryId)
        {
            var usageHistory = await _context.UsageHistories.FindAsync(UsageHistoryId);
            if (usageHistory != null)
            {
                usageHistory.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

        
        
    }
}
