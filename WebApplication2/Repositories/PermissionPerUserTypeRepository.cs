using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;


    public interface IPermissionPerUserTypeRepository
    {
        Task<IEnumerable<PermissionPerUserType>> GetAllPermissionsPerUserTypeAsync();
        Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int id, int permissionId);
        Task CreatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType);
        Task UpdatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType);
        Task DeletePermissionPerUserTypeAsync(int id, int permissionId);
    }

    public class PermissionPerUserTypeRepository : IPermissionPerUserTypeRepository
    {
        private readonly TestContext _context;

        public PermissionPerUserTypeRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PermissionPerUserType>> GetAllPermissionsPerUserTypeAsync()
        {
            return await _context.PermissionsPerUserTypes
                .Where(pput => !pput.IsDeleted) // Excluye los eliminados
                .ToListAsync();
        }

        public async Task<PermissionPerUserType> GetPermissionPerUserTypeByIdAsync(int id)
        {
            return await _context.PermissionsPerUserTypes
                .FirstOrDefaultAsync(pput => pput.PermissionPerUserTypeId == id && !pput.IsDeleted);
        }

        public async Task CreatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType)
        {
            try
            {
                await _context.PermissionsPerUserType.AddAsync(permissionPerUserType);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw; // Manejo de excepción opcional
            }
        }

        public async Task UpdatePermissionPerUserTypeAsync(PermissionPerUserType permissionPerUserType)
        {
            _context.PermissionsPerUserTypes.Update(permissionPerUserType);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePermissionPerUserTypeAsync(int id)
        {
            var permissionPerUserType = await _context.PermissionsPerUserTypes.FindAsync(id);
            if (permissionPerUserType != null)
            {
                permissionPerUserType.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
        }
    }

