using SGME.Model;

namespace SGME.Repositories
{
    public interface IUsageHistoryService
    {
        Task<IEnumerable<UsageHistory>> GetAllUsageHistoriesAsync();
        Task<UsageHistory> GetUsageHistoryByIdAsync(int id);
        Task CreateUsageHistoryAsync(UsageHistory usageHistory);
        Task UpdateUsageHistoryAsync(UsageHistory usageHistory);
        Task DeleteUsageHistoryAsync(int id);
    }

    public class UsageHistoryService : IUsageHistoryService
    {
        private readonly IUsageHistoryRepository _usageHistoryRepository;

        public UsageHistoryService(IUsageHistoryRepository usageHistoryRepository)
        {
            _usageHistoryRepository = usageHistoryRepository;
        }

        public async Task<IEnumerable<UsageHistory>> GetAllUsageHistoriesAsync()
        {
            return await _usageHistoryRepository.GetAllUsageHistoriesAsync();
        }

        public async Task<UsageHistory> GetUsageHistoryByIdAsync(int id)
        {
            return await _usageHistoryRepository.GetUsageHistoryByIdAsync(id);
        }

        public async Task CreateUsageHistoryAsync(UsageHistory usageHistory)
        {
            await _usageHistoryRepository.CreateUsageHistoryAsync(usageHistory);
        }

        public async Task UpdateUsageHistoryAsync(UsageHistory usageHistory)
        {
            await _usageHistoryRepository.UpdateUsageHistoryAsync(usageHistory);
        }

        public async Task DeleteUsageHistoryAsync(int id)
        {
            await _usageHistoryRepository.DeleteUsageHistoryAsync(id);
        }
    }
}
