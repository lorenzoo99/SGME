using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SGME.Model;
using WebApplication2.Context;

namespace SGME.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(string name, string email, string password, int userTypeId);
        Task UpdateUserAsync(int id, string name, string email, string password, int userTypeId);
        Task<bool> ValidateUserAsync(string email, string password);
        Task SoftDeleteUserAsync(int id);
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
                .Where(u => !u.IsDeleted)
                .Include(u => u.UserType)// Excluye los eliminados
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.AsNoTracking()
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task CreateUserAsync(string name, string email, string password, int userTypeId)
        {
            // Fetch the UserType
            var UserType = await _context.UserTypes.FindAsync(userTypeId) ?? throw new Exception("UserType not found");

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(null, password);

            // Create a new User object
            var user = new User
            {
                Name = name,
                Email = email,
                Password = hashedPassword,
                UserType = UserType
            };
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw; // Manejo de excepción opcional
            }
        }

        public async Task UpdateUserAsync(int id, string name, string email, string password, int userTypeId)
        {
            // Find the existing user by ID
            var user = await _context.Users.FindAsync(id) ?? throw new Exception("User not found");

            // Fetch the User object based on userId and attendantId
            var userType = await _context.UserTypes.FindAsync(userTypeId) ?? throw new Exception("UserType not found");

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(user, password);

            // Update
            user.Name = name;
            user.Email = email;
            user.Password = hashedPassword;
            user.UserType = userType;

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            // Fetch the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception("User not found");

            // User does not exist
            if (user == null) return false;

            // Initialize PasswordHasher
            var passwordHasher = new PasswordHasher<User>();

            // Verify the password
            var userVerification = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            // Check if password is correct
            if (userVerification == PasswordVerificationResult.Success) return true;

            // Password is invalid
            return false;
        }


    }
}