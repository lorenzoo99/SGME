using SGME.Model;

public interface IPermissionsService
{
    Task<IEnumerable<Permissions>> GetAllPermissionsAsync();
    Task<Permissions> GetPermissionsByIdAsync(int id);
    Task CreatePermissionsAsync(Permissions permissions);
    Task UpdatePermissionsAsync(Permissions permissions);
    Task DeletePermissionsAsync(int id);

 
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

    public async Task<Permissions> GetPermissionsByIdAsync(int id)
    {
        return await _permissionsRepository.GetPermissionsByIdAsync(id);
    }

    public async Task CreatePermissionsAsync(Permissions permissions)
    {
        await _permissionsRepository.CreatePermissionsAsync(permissions);
    }

    public async Task UpdatePermissionsAsync(Permissions permissions)
    {
        await _permissionsRepository.UpdatePermissionsAsync(permissions);
    }

    public Task DeletePermissionsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SoftDeletePermissionsAsync(int id)
    {
        throw new NotImplementedException();
    }
}

