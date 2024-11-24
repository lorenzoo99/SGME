using SGME.Model;
using SGME.Repositories;
using SGME.Services;


public interface IUserService
{
    Task<IEnumerable<User>> GetAllUserAsync();
    Task<User> GetUserByIdSync(int UserId);
    Task CreateUserAsync(string Name, string Email, string Password, DateTime Date, int UserTypeId);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int UserId);

    Task<User> LoginAsync(string email, string password);

}


public class UserService : IUserService

{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllUserAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<User> GetUserByIdSync(int UserId)
    {
        return await _userRepository.GetUserByIdAsync(UserId);
    }


    public async Task CreateUserAsync(string Name, string Email, string Password, DateTime Date, int UserTypeId)
    {
        await _userRepository.CreateUserAsync(Name, Email, Password, Date, UserTypeId);
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);
    }
    public async Task<User> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null || user.IsDeleted)
        {
            return null;
        }


        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            return null;
        }

        return user;
    }

    public async Task DeleteUserAsync(int UserId)
    {
        await _userRepository.SoftDeleteUserAsync(UserId);
    }


}