
﻿using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;



public interface IPermissionsRepository
{
    Task<IEnumerable<Permissions>> GetAllPermissionsAsync();

    Task<Permissions> GetPermissionsByIdAsync(int id);
    Task CreatePermissionsAsync(Permissions permissions);
    Task UpdatePermissionsAsync(Permissions permissions);
    Task DeletePermissionsAsync(int id);
    Task SoftDeletePermissionsAsync(int id);

}

public class PermissionsRepository : IPermissionsRepository
{

    private readonly TestContext _context;

    public PermissionsRepository(TestContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Permissions>> GetAllPermissionsAsync()
    {
        return await _context.Permissions
            .Where(p => !p.IsDeleted) // Excluye los eliminados
            .ToListAsync();
    }

    public async Task<Permissions> GetPermissionsByIdAsync(int id)
    {
        return await _context.Permissions
            .FirstOrDefaultAsync(p => p.PermissionID == id && !p.IsDeleted);
    }

    public async Task CreatePermissionsAsync(Permissions permissions)
    {
        try
        {
            await _context.Permissions.AddAsync(permissions);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw; // Manejo de excepción opcional
        }
    }

    public async Task UpdatePermissionsAsync(Permissions permissions)
    {
        _context.Permissions.Update(permissions);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePermissionsAsync(int id)
    {
        var permissions = await _context.Permissions.FindAsync(id);
        if (permissions != null)
        {
            permissions.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
        }

    }

    public Task SoftDeletePermissionsAsync(int id)
    {
        throw new NotImplementedException();
    }
}