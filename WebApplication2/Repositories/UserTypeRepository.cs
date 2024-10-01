using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;

namespace SGME.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int TypeId);
        Task CreateUserTypeAsync(string Name, string UserTypeName, string UserTypeDescription, UserType userType);
        Task UpdateUserTypeAsync(int UserTypeId, string Name, string UserTypeName, string UserTypeDescription, UserType userType);
        Task DeleteUserTypeAsync(int UserTypeId);
        
    }

    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly TestContext _context;

        public UserTypeRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            return await _context.UserTypes
                .Where(ut => !ut.IsDeleted)
                .ToListAsync();
        }

        public async Task<UserType> GetUserTypeByIdAsync(int UserTypeId)
        {
            return await _context.UserTypes
                .FirstOrDefaultAsync(ut => ut.Id == UserTypeId && !ut.IsDeleted);
        }

        public async Task CreateUserTypeAsync(string Name, string UserTypeName, string UserTypeDescription, UserType userType)
        {
            try
            {
                await _context.UserTypes.AddAsync(userType);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw; // Manejo de excepción opcional
            }
        }

        public async Task UpdateUserTypeAsync(int UserTypeId, string Name, string UserTypeName, string UserTypeDescription, UserType userType)
        {
            _context.UserTypes.Update(userType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserTypeAsync(int UserTypeId)
        {
            var userType = await _context.UserTypes.FindAsync(UserTypeId);
            if (userType != null)
            {
                userType.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

  
    }
}
