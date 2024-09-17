using SGME.Model;


    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdSync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync (User user);
        Task SoftDeleteUser(int id);
    }

public class UserRepository : IUserRepository


{
    public UserRepository()
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
