using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;

public interface IPlatformRepository
{
    Task<IEnumerable<Platform>> GetAllPlatformsAsync();
    Task<Platform> GetPlatformByIdAsync(int id);
    Task CreatePlatformAsync(Platform platform);
    Task UpdatePlatformAsync(Platform platform);
    Task DeletePlatformAsync(int id);
}

public class PlatformRepository : IPlatformRepository
{
    private readonly TestContext _context;

    public PlatformRepository(TestContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
    {
        return await _context.Platforms
            .Where(p => !p.IsDeleted) // Excluye los eliminados
            .ToListAsync();
    }

    public async Task<Platform> GetPlatformByIdAsync(int id)
    {
        return await _context.Platforms
            .FirstOrDefaultAsync(p => p.PlatformID == id && !p.IsDeleted);
    }

    public async Task CreatePlatformAsync(Platform platform)
    {
        try
        {
            await _context.Platforms.AddAsync(platform);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw; // Manejo de excepción opcional
        }
    }

    public async Task UpdatePlatformAsync(Platform platform)
    {
        _context.Platforms.Update(platform);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePlatformAsync(int id)
    {
        var platform = await _context.Platforms.FindAsync(id);
        if (platform != null)
        {
            platform.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
        }
    }
}