using SGME.Model;

public interface IPermissionsService
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
