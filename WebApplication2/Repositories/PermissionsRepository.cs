
﻿using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;



public interface IPermissionsRepository
{
    Task<IEnumerable<Permissions>> GetAllPermissionsAsync();

    Task<Permissions> GetPermissionsByIdAsync(int PermissionsId);
    Task CreatePermissionsAsync(string PermissionName, string PermissionDescription, Permissions permissions);
    Task UpdatePermissionsAsync(int PermissionsId, string PermissionName, string PermissionDescription, Permissions permissions);
    Task DeletePermissionsAsync(int PermissionsId);
   

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

    public async Task<Permissions> GetPermissionsByIdAsync(int PermissionsId)
    {
        return await _context.Permissions
            .FirstOrDefaultAsync(p => p.PermissionID == PermissionsId && !p.IsDeleted);
    }

    public async Task CreatePermissionsAsync(string PermissionName, string PermissionDescription, Permissions permissions)
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

    public async Task UpdatePermissionsAsync(int PermissionsId, string PermissionName, string PermissionDescription, Permissions permissions)
    {
        _context.Permissions.Update(permissions);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePermissionsAsync(int PermissionsId)
    {
        var permissions = await _context.Permissions.FindAsync(PermissionsId);
        if (permissions != null)
        {
            permissions.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
        }

    }

    
    
}