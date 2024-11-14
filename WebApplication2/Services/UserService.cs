using SGME.Model;
using SGME.Repositories;
using SGME.Services;


public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task CreateUserAsync(string name, string email, string password, int userTypeId);
    Task UpdateUserAsync(int id, string name, string email, string password, int userTypeId);
    Task SoftDeleteUserAsync(int id);
    Task<bool> ValidateUserAsync(string email, string password);

}


public class UserService : IUserService

{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task CreateUserAsync(string name, string email, string password, int userTypeId)
    {
        await _userRepository.CreateUserAsync(name, email, password, userTypeId);
    }

    public async Task UpdateUserAsync(int id, string name, string email, string password, int userTypeId)
    {
        try
        {
            await _userRepository.UpdateUserAsync(id, name, email, password, userTypeId);
        }
        catch (Exception e)
        {

            throw;
        }
    }
    public async Task SoftDeleteUserAsync(int id)
    {
        await _userRepository.SoftDeleteUserAsync(id);
    }

    public async Task<bool> ValidateUserAsync(string email, string password)
    {
        try
        {
            return await _userRepository.ValidateUserAsync(email, password);
        }
        catch (Exception e)
        {
            throw;
        }

    }


}