
﻿using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;



public interface IPermissionsRepository
{
    Task<IEnumerable<Permissions>> GetAllPermissionsAsync();

    Task<Permissions> GetPermissionByIdAsync(int id);
    Task CreatePermissionAsync(Permissions permission);
    Task UpdatePermissionAsync(Permissions permission);
    Task DeletePermissionAsync(int id);

    Task<Permissions> GetPermissionsByIdAsync(int id);
    Task CreatePermissionsAsync(Permissions permissions);
    Task UpdatePermissionsAsync(Permissions permissions);
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

    public async Task<Permissions> GetPermissionByIdAsync(int id)
    {
        return await _context.Permissions
            .FirstOrDefaultAsync(p => p.PermissionID == id && !p.IsDeleted);
    }

    public async Task CreatePermissionAsync(Permissions permission)
    {
        try
        {
            await _context.Permissions.AddAsync(permission);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw; // Manejo de excepción opcional
        }
    }

    public async Task UpdatePermissionAsync(Permissions permission)
    {
        _context.Permissions.Update(permission);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePermissionAsync(int id)
    {
        var permission = await _context.Permissions.FindAsync(id);
        if (permission != null)
        {
            permission.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
        }

    public Task CreatePermissionsAsync(Permissions permissions)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Permissions>> GetAllPermissionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Permissions> GetPermissionsByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SoftDeletePermissionsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePermissionsAsync(Permissions permissions)
    {
        throw new NotImplementedException();

    }
}