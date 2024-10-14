using SGME.Model;
using SGME.Repositories;
using SGME.Services;

namespace SGME.Services
{
    public interface IUsageHistoryService
    {
        Task<IEnumerable<UsageHistory>> GetAllUsageHistoriesAsync();
        Task<UsageHistory> GetUsageHistoryByIdAsync(int UsageHistoryId);
        Task CreateUsageHistoryAsync(int ViewDuration, UsageHistory usageHistory);
        Task UpdateUsageHistoryAsync(int UsageHistoryId, int ViewDuration, UsageHistory usageHistory);
        Task DeleteUsageHistoryAsync(int UsageHistoryId);

    }

    public class UsageHistoryService : IUsageHistoryService
    {
        private readonly IUsageHistoryRepository _usageHistoryRepository;

        public UsageHistoryService(IUsageHistoryRepository usageHistoryRepository)
        {
            _usageHistoryRepository = usageHistoryRepository;
        }

        public async Task<IEnumerable<UserType>> GetAllUsageHistoriesAsync()
        {
            return await _usageHistoryRepository.GetAllUsageHistoriesAsync();
        }
        public async Task<UsageHistory> GetUsageHistoryByIdAsync(int UsageHistoryId)
        {
            return await _usageHistoryRepository.GetUsageHistoryByIdAsync(UsageHistoryId);
        }


        public async Task CreateUsageHistoryAsync(int ViewDuration, UsageHistory usageHistory)
        {
            await _usageHistoryRepository.CreateUsageHistoryAsync(ViewDuration, usageHistory);
        }

        public async Task UpdateUsageHistoryAsync(int UsageHistoryId, int ViewDuration, UsageHistory usageHistory)
        {
            await _usageHistoryRepository.UpdateUsageHistoryAsync(UsageHistoryId, ViewDuration, usageHistory);
        }

        public async Task DeleteUsageHistoryAsync(int UsageHistoryId)
        {
            await _usageHistoryRepository.DeleteUsageHistoryAsync(UsageHistoryId);
        }

        
    }
}