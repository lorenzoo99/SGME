using SGME.Model;

namespace SGME.Services
{
    public interface IPermissionPerUserTypeService
    {
        Task<IEnumerable<PermissionPerUserType>> GetAllPermissionsPerUserTypeAsync();
        Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int UserTypeId, int PermissionPerUserTypeId);
        Task CreatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType);
        Task UpdatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType);
        Task DeletePermissionPerUserTypeAsync(int UserTypeId, int PermissionPerUserTypeId);
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

        public async Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int UserTypeId, int PermissionPerUserTypeId)
        {
            return await _permissionPerUserTypeRepository.GetPermissionPerUserTypeByIdAsync(UserTypeId, PermissionPerUserTypeId);
        }

        public async Task CreatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType)
        {
            await _permissionPerUserTypeRepository.CreatePermissionPerUserTypeAsync(permissionPerUserType);
        }

        public async Task UpdatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType)
        {
            await _permissionPerUserTypeRepository.UpdatePermissionPerUserTypeAsync(permissionPerUserType);
        }

        public async Task DeletePermissionPerUserTypeAsync(int UserTypeId, int PermissionPerUserTypeId)
        {
            await _permissionPerUserTypeRepository.DeletePermissionPerUserTypeAsync(UserTypeId, PermissionPerUserTypeId);
        }
    }
}
