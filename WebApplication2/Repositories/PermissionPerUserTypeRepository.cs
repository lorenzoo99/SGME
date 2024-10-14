using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;


    public interface IPermissionPerUserTypeRepository
    {
        Task<IEnumerable<PermissionPerUserType>> GetAllPermissionPerUserTypeAsync();
        Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int UserTypeId, int PermissionPerUserTypeId);
        Task CreatePermissionPerUserTypeAsync(int UserTypeID, PermissionPerUserType permissionPerUserType);
        Task UpdatePermissionPerUserTypeAsync(int UserTypeId, int PermissionPerUserTypeId, PermissionPerUserType permissionPerUserType);
        Task DeletePermissionPerUserTypeAsync(int userTypeId, int permissionId);
    }

public class PermissionPerUserTypeRepository : IPermissionPerUserTypeRepository
{
    private readonly TestContext _context;

    public PermissionPerUserTypeRepository(TestContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PermissionPerUserType>> GetAllPermissionPerUserTypeAsync()
    {
        return await _context.PermissionPerUserTypes
            .Where(pput => !pput.IsDeleted) // Excluye los eliminados
            .ToListAsync();
    }

    public async Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int UserTypeId, int PermissionPerUserTypeId)
    {
        return await _context.PermissionPerUserTypes
            .FirstOrDefaultAsync(pput => pput.PermissionPerUserTypeID == PermissionPerUserTypeId && !pput.IsDeleted);
    }

    public async Task CreatePermissionPerUserTypeAsync(int UserTypeID, PermissionPerUserType permissionPerUserType)
    {
        try
        {
            await _context.PermissionPerUserTypes.AddAsync(permissionPerUserType);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw; // Manejo de excepción opcional
        }
    }

    public async Task UpdatePermissionPerUserTypeAsync(int UserTypeId, int PermissionPerUserTypeId, PermissionPerUserType permissionPerUserType)
    {
        _context.PermissionPerUserTypes.Update(permissionPerUserType);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePermissionPerUserTypeAsync(int UserTypeId, int PermissionPerUserTypeId)
    {
        var permissionPerUserType = await _context.PermissionPerUserTypes.FindAsync(UserTypeId, PermissionPerUserTypeId);
        if (permissionPerUserType != null)
        {
            permissionPerUserType.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
        }
    }


}



    

