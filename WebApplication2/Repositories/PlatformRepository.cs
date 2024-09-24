using SGME.Model;

public interface IPlatformRepository
    {
        Task<IEnumerable<Platform>> GetAllPlatformAsync();
        Task<Platform> GetPlatformByIdAsync(int id);
        Task CreatePlatformAsync(Platform platform);
        Task UpdatePlatformAsync(Platform platform);
        Task SoftDeletePlatformAsync(int id);
    }

    public class PlatformRepository : IPlatformRepository
    {
        public Task CreatePlatformAsync(Platform platform)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Platform>> GetAllPlatformAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Platform> GetPlatformByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeletePlatformAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlatformAsync(Platform platform)
        {
            throw new NotImplementedException();
        }
    }