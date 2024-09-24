using SGME.Model;

namespace SGME.Repositories
{
    public interface IPermissionPerUserTypeService
    {
        Task<IEnumerable<PermissionPerUserType>> GetAllPermissionsPerUserTypeAsync();
        Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int userTypeId, int permissionId);
        Task CreatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType);
        Task UpdatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType);
        Task DeletePermissionPerUserTypeAsync(int userTypeId, int permissionId);
    }

    public class PermissionPerUserTypeService : IPermissionPerUserTypeService
    {
        private readonly IPermissionPerUserTypeRepository _permissionPerUserTypeRepository;

        public PermissionPerUserTypeService(IPermissionPerUserTypeRepository permissionPerUserTypeRepository)
        {
            _permissionPerUserTypeRepository = permissionPerUserTypeRepository;
        }

        public async Task<IEnumerable<PermissionPerUserType>> GetAllPermissionsPerUserTypeAsync()
        {
            return await _permissionPerUserTypeRepository.GetAllPermissionsPerUserTypeAsync();
        }

        public async Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int userTypeId, int permissionId)
        {
            return await _permissionPerUserTypeRepository.GetPermissionPerUserTypeByIdAsync(userTypeId, permissionId);
        }

        public async Task CreatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType)
        {
            await _permissionPerUserTypeRepository.CreatePermissionPerUserTypeAsync(permissionPerUserType);
        }

        public async Task UpdatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType)
        {
            await _permissionPerUserTypeRepository.UpdatePermissionPerUserTypeAsync(permissionPerUserType);
        }

        public async Task DeletePermissionPerUserTypeAsync(int userTypeId, int permissionId)
        {
            await _permissionPerUserTypeRepository.DeletePermissionPerUserTypeAsync(userTypeId, permissionId);
        }
    }
}
