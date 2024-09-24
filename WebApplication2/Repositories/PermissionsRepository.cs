using SGME.Model;

public interface IPermissionsRepository
{
    Task<IEnumerable<Permissions>> GetAllPermissionsAsync();
    Task<Permissions> GetPermissionsByIdAsync(int id);
    Task CreatePermissionsAsync(Permissions permissions);
    Task UpdatePermissionsAsync(Permissions permissions);
    Task SoftDeletePermissionsAsync(int id);
}

public class PermissionsRepository : IPermissionsRepository
{
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