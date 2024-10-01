using SGME.Model;

public interface IPlatformService
{
    Task<IEnumerable<Platform>> GetAllPlatformsAsync();
    Task<Platform> GetPlatformByIdAsync(int PlatformId);
    Task CreatePlatformAsync(string PlatformName, string PlatformDescription, Platform platform);
    Task UpdatePlatformAsync(int PlatformId, string PlatformName, string PlatformDescription, Platform platform);
    Task DeletePlatformAsync(int PlatformId);
    
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

    public async Task<Platform> GetPlatformByIdAsync(int PlatformId)
    {
        return await _platformRepository.GetPlatformByIdAsync(PlatformId);
    }

    public async Task CreatePlatformAsync(string PlatformName, string PlatformDescription, Platform platform)
    {
        await _platformRepository.CreatePlatformAsync(PlatformName, PlatformDescription, platform);
    }

    public async Task UpdatePlatformAsync(int PlatformId, string PlatformName, string PlatformDescription, Platform platform)
    {
        await _platformRepository.UpdatePlatformAsync(PlatformId, PlatformName, PlatformDescription, platform);
    }

    public async Task DeletePlatformAsync(int PlatformId)
    {
        await _platformRepository.DeletePlatformAsync(PlatformId);
    }
}
    

   

    

    

 
    

