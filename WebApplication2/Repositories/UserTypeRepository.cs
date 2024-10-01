using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;

namespace SGME.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(UserType userType);
        Task UpdateUserTypeAsync(UserType userType);
        Task DeleteUserTypeAsync(int id);
        Task SoftDeleteUserTypeAsync(int userTypeId);
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

        public async Task<UserType> GetUserTypeByIdAsync(int id)
        {
            return await _context.UserTypes
                .FirstOrDefaultAsync(ut => ut.Id == id && !ut.IsDeleted);
        }

        public async Task CreateUserTypeAsync(UserType userType)
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

        public async Task UpdateUserTypeAsync(UserType userType)
        {
            _context.UserTypes.Update(userType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserTypeAsync(int id)
        {
            var userType = await _context.UserTypes.FindAsync(id);
            if (userType != null)
            {
                userType.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

        public Task SoftDeleteUserTypeAsync(int userTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
