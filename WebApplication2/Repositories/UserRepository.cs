using DSS.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SGME.Model;
using WebApplication2.Context;

namespace SGME.Repositories
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int userId);
        Task<User?> GetUserByEmailAsync(string email);
        Task CreateUserAsync(string Name, string Email, string Password, DateTime Date, int UserTypeId);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int userId);



    }



    public class UserRepository : IUserRepository
    {
        private readonly TestContext _context;

        public UserRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => !u.IsDeleted)
                .ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }

        public async Task CreateUserAsync(string Name, string Email, string Password, DateTime Date, int UserTypeId)
        {
            var userType = await _context.UserTypes.FindAsync(UserTypeId) ?? throw new Exception("UserType not found");
            var user = new User
            {
                Name = Name,
                Email = Email,
                Password = Password,
                Date = Date,
                UserType = userType,
                ContentUsers = null,
            };
            

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) throw new KeyNotFoundException("User not found");

            user.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}