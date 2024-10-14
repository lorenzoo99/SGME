using SGME.Model;

namespace SGME.Services
{
    public interface IPermissionPerUserTypeService
    {
        Task<IEnumerable<PermissionPerUserType>> GetAllPermissionPerUserTypeAsync();
        Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int UserTypeId, int PermissionPerUserTypeId);
        Task CreatePermissionPerUserTypeAsync(int UserTypeID, PermissionPerUserType permissionPerUserType);
        Task UpdatePermissionPerUserTypeAsync(int UserTypeId, int PermissionPerUserTypeId, PermissionPerUserType permissionPerUserType);
        Task DeletePermissionPerUserTypeAsync(int UserTypeId, int PermissionPerUserTypeId);
        
    }

    public class PermissionPerUserTypeService : IPermissionPerUserTypeService
    {
        private readonly IPermissionPerUserTypeRepository _permissionPerUserTypeRepository;

        public PermissionPerUserTypeService(IPermissionPerUserTypeRepository permissionPerUserTypeRepository)
        {
            _permissionPerUserTypeRepository = permissionPerUserTypeRepository;
        }

        public async Task<IEnumerable<PermissionPerUserType>> GetAllPermissionPerUserTypeAsync()
        {
            return await _permissionPerUserTypeRepository.GetAllPermissionPerUserTypeAsync();
        }

        public async Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int UserTypeId, int PermissionPerUserTypeId)
        {
            return await _permissionPerUserTypeRepository.GetPermissionPerUserTypeByIdAsync(UserTypeId, PermissionPerUserTypeId);
        }

        public async Task CreatePermissionPerUserTypeAsync(int UserTypeID, PermissionPerUserType permissionPerUserType)
        {
            await _permissionPerUserTypeRepository.CreatePermissionPerUserTypeAsync(UserTypeID, permissionPerUserType);
        }

        public async Task UpdatePermissionPerUserTypeAsync(int UserTypeId, int PermissionPerUserTypeId, PermissionPerUserType permissionPerUserType)
        {
            await _permissionPerUserTypeRepository.UpdatePermissionPerUserTypeAsync(UserTypeId, PermissionPerUserTypeId, permissionPerUserType);
        }

        public async Task DeletePermissionPerUserTypeAsync(int UserTypeId, int PermissionPerUserTypeId)
        {
            await _permissionPerUserTypeRepository.DeletePermissionPerUserTypeAsync(UserTypeId, PermissionPerUserTypeId);
        }
    }
}
