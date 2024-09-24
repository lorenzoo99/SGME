using SGME.Model;

public interface IPlatformService
{
    Task<IEnumerable<Platform>> GetAllPlatformsAsync();
    Task<Platform> GetPlatformByIdAsync(int id);
    Task CreatePlatformAsync(Platform platform);
    Task UpdatePlatformAsync(Platform platform);
    Task DeletePlatformAsync(int id);
}

public class PlatformService : IPlatformService
{
    private readonly IPlatformRepository _platformRepository;

    public PlatformService(IPlatformRepository platformRepository)
    {
        _platformRepository = platformRepository;
    }

    public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
    {
        return await _platformRepository.GetAllPlatformsAsync();
    }

    public async Task<Platform> GetPlatformByIdAsync(int id)
    {
        return await _platformRepository.GetPlatformByIdAsync(id);
    }

    public async Task CreatePlatformAsync(Platform platform)
    {
        await _platformRepository.CreatePlatformAsync(platform);
    }

    public async Task UpdatePlatformAsync(Platform platform)
    {
        await _platformRepository.UpdatePlatformAsync(platform);
    }

    public async Task DeletePlatformAsync(int id)
    {
        await _platformRepository.DeletePlatformAsync(id);
    }
}