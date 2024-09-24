using SGME.Model;


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
