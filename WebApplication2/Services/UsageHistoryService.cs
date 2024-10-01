using SGME.Model;
using SGME.Repositories;

namespace SGME.Services
{
    public interface IUsageHistoryService
    {
        Task<IEnumerable<UserType>> GetAllUsageHistoriesAsync();
        Task<UserType> GetUsageHistoryByIdAsync(int id);
        Task CreateUsageHistoryAsync(UserType usageHistory);
        Task UpdateUsageHistoryAsync(UserType usageHistory);
        Task DeleteUsageHistoryAsync(int id);

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

        public async Task<UserType> GetUsageHistoryByIdAsync(int id)
        {
            return await _usageHistoryRepository.GetUsageHistoryByIdAsync(id);
        }

        public async Task CreateUsageHistoryAsync(UserType usageHistory)
        {
            await _usageHistoryRepository.CreateUsageHistoryAsync(usageHistory);
        }

        public async Task UpdateUsageHistoryAsync(UserType usageHistory)
        {
            await _usageHistoryRepository.UpdateUsageHistoryAsync(usageHistory);
        }

        public async Task DeleteUsageHistoryAsync(int id)
        {
            await _usageHistoryRepository.DeleteUsageHistoryAsync(id);
        }

    }
}