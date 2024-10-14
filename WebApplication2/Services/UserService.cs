using SGME.Model;
using SGME.Repositories;
using SGME.Services;


    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdSync(int UserId);
        Task CreateUserAsync(string Name, string Email, string Password, User user);
        Task UpdateUserAsync (int UserId, string Name, string Email, string Password, User user);
        Task DeleteUserAsync(int UserId);
    
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
        return await _userRepository.GetAllUserAsync();
    }

    public async Task<User> GetUserByIdSync(int UserId)
    {
        return await _userRepository.GetUserByIdAsync(UserId);
    }

    public async Task CreateUserAsync(string Name, string Email, string Password, User user)
    {
        await _userRepository.CreateUserAsync(Name, Email, Password, user);
    }

    public async Task UpdateUserAsync(int UserId, string Name, string Email, string Password, User user)
    {
        await _userRepository.UpdateUserAsync(UserId, Name, Email, Password, user);
    }

    public async Task DeleteUserAsync(int UserId)
    {
        await _userRepository.DeleteUserAsync(UserId);
    }

    
}