using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;


    public interface IPermissionPerUserTypeRepository
    {
        Task<IEnumerable<PermissionPerUserType>> GetAllPermissionsPerUserTypeAsync();
        Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int userTypeId, int permissionId);
        Task CreatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType);
        Task UpdatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType);
        Task DeletePermissionPerUserTypeAsync(int userTypeId, int permissionId);
    }

    public class PermissionPerUserTypeRepository : IPermissionPerUserTypeRepository
    {
        private readonly TestContext _context;

        public PermissionPerUserTypeRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PermissionPerUserType>> GetAllPermissionsPerUserTypesAsync()
        {
        return await _context.PermissionPerUserTypes
            .Where(pput => !pput.IsDeleted) // Excluye los eliminados
            .ToListAsync();
        }

        public async Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int id)
        {
            return await _context.PermissionPerUserTypes
                .FirstOrDefaultAsync(pput => pput.PermissionPerUserTypeID == id && !pput.IsDeleted);
        }

        public async Task CreatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType)
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

        public async Task UpdatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType)
        {
            _context.PermissionPerUserTypes.Update(permissionPerUserType);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePermissionPerUserTypeAsync(int id)
        {
            var permissionPerUserType = await _context.PermissionPerUserTypes.FindAsync(id);
            if (permissionPerUserType != null)
            {
                permissionPerUserType.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

    public Task<IEnumerable<PermissionPerUserType>> GetAllPermissionsPerUserTypeAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int userTypeId, int permissionId)
    {
        throw new NotImplementedException();
    }

    public Task DeletePermissionPerUserTypeAsync(int userTypeId, int permissionId)
    {
        throw new NotImplementedException();
    }
}


    

