using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;

namespace SGME.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(string name);
        Task UpdateUserTypeAsync(int id, string name);
        Task SoftDeleteUserTypeAsync(int id);

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

        public async Task CreateUserTypeAsync(string name)
        {
            var userType = new UserType
            {
                UserTypeName = name,
            };

            await _context.UserTypes.AddAsync(userType);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateUserTypeAsync(int id, string name)
        {
            var userType = await _context.UserTypes.FindAsync(id) ?? throw new Exception("UserType not found");

            userType.UserTypeName = name;

            try
            {
                _context.UserTypes.Update(userType);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw;

            }
        }
        public async Task SoftDeleteUserTypeAsync(int id)
        {
            var usertype = await _context.UserTypes.FindAsync(id);
            if (usertype != null)
            {
                usertype.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }

    }
}
