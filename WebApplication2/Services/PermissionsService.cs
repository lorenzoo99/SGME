using SGME.Model;
using System.Security;

public interface IPermissionsService
{
    Task<IEnumerable<Permissions>> GetAllPermissionsAsync();
    Task<Permissions> GetPermissionsByIdAsync(int PermissionsId);
    Task CreatePermissionsAsync(string PermissionName, string PermissionDescription, Permissions permissions);
    Task UpdatePermissionsAsync(int PermissionsId, string PermissionName, string PermissionDescription, Permissions permissions);
    Task DeletePermissionsAsync(int PermissionsId);

 
    Task SoftDeletePermissionsAsync(int id);

    
}

public class PermissionsService : IPermissionsService
{

    private readonly IPermissionsRepository _permissionsRepository;

    public PermissionsService(IPermissionsRepository permissionsRepository)
    {
        _permissionsRepository = permissionsRepository;
    }

    public async Task<IEnumerable<Permissions>> GetAllPermissionsAsync()
    {
        return await _permissionsRepository.GetAllPermissionsAsync();
    }

    public async Task<Permissions> GetPermissionsByIdAsync(int PermissionsId)
    {
        return await _permissionsRepository.GetPermissionsByIdAsync(PermissionsId);
    }

    public async Task CreatePermissionsAsync(string PermissionName, string PermissionDescription, Permissions permissions)
    {
        await _permissionsRepository.CreatePermissionsAsync(PermissionName, PermissionDescription, permissions);
    }

    public async Task UpdatePermissionsAsync(int PermissionsId, string PermissionName, string PermissionDescription, Permissions permissions)
    {
        await _permissionsRepository.UpdatePermissionsAsync(PermissionsId, PermissionName, PermissionDescription, permissions);
    }

    public async Task DeletePermissionsAsync(int PermissionsId)
    {
        await _permissionsRepository.DeletePermissionsAsync(PermissionsId);

    }

    public Task SoftDeletePermissionsAsync(int id)
    {
        throw new NotImplementedException();
    }
}

