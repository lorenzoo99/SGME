using SGME.Model;

using SGME.Repositories;


public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
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

    public async Task CreateUserAsync(User user)
    {
        await _userRepository.CreateUserAsync(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteUserAsync(id);
    }
}



    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdSync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync (User user);
        Task SoftDeleteUser(int id);
    }

public class UserService : IUserService


{
    public UserService()
    {
        
    }
    public Task CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllUserAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByIdSync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SoftDeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}

