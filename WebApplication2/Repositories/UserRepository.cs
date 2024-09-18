using WebApplication2.Model;

namespace SGME.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);


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

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
