using SGME.Model;
using SGME.Repositories;
using SGME.Services;


    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdSync(int UserId);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync (User user);
        Task SoftDeleteUserAsync(int UserId);
    
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

    public async Task<User> GetUserByIdAsync(int UserId)
    {
        return await _userRepository.GetUserByIdAsync(UserId);
    }

    public async Task CreateUserAsync(User user)
    {
        await _userRepository.CreateUserAsync(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);
    }

    public async Task SoftDeleteUserAsync(int UserId)
    {
        await _userRepository.SoftDeleteUserAsync(UserId);
    }

    public Task<User> GetUserByIdSync(int UserId)
    {
        throw new NotImplementedException();
    }
}