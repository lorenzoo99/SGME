using SGME.Model;

public interface IPermissionsService
{
    Task<IEnumerable<Permissions>> GetAllPermissionsAsync();
    Task<Permissions> GetPermissionByIdAsync(int id);
    Task CreatePermissionAsync(Permissions permission);
    Task UpdatePermissionAsync(Permissions permission);
    Task DeletePermissionAsync(int id);
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

    public async Task<Permissions> GetPermissionByIdAsync(int id)
    {
        return await _permissionsRepository.GetPermissionByIdAsync(id);
    }

    public async Task CreatePermissionAsync(Permissions permission)
    {
        await _permissionsRepository.CreatePermissionAsync(permission);
    }

    public async Task UpdatePermissionAsync(Permissions permission)
    {
        await _permissionsRepository.UpdatePermissionAsync(permission);
    }

    public async Task DeletePermissionAsync(int id)
    {
        await _permissionsRepository.DeletePermissionAsync(id);
    }
}
