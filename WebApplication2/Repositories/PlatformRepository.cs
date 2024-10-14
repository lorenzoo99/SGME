
﻿using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;

public interface IPlatformRepository
{
    Task<IEnumerable<Platform>> GetAllPlatformsAsync();
    Task<Platform> GetPlatformByIdAsync(int PlatformId);
    Task CreatePlatformAsync(string PlatformName, string PlatformDescription, Platform platform);
    Task UpdatePlatformAsync(int PlatformId, string PlatformName, string PlatformDescription, Platform platform);
    Task DeletePlatformAsync(int PlatformId);
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

    public async Task<Platform> GetPlatformByIdAsync(int PlatformId)
    {
        return await _context.Platforms
            .FirstOrDefaultAsync(p => p.PlatformID == PlatformId && !p.IsDeleted);
    }

    public async Task CreatePlatformAsync(string PlatformName, string PlatformDescription, Platform platform)
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

    public async Task UpdatePlatformAsync(int PlatformId, string PlatformName, string PlatformDescription, Platform platform)
    {
        _context.Platforms.Update(platform);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePlatformAsync(int PlatformId)
    {
        var platform = await _context.Platforms.FindAsync(PlatformId);
        if (platform != null)
        {
            platform.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
        }
    }
}


