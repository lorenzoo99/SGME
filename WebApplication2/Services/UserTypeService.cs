using SGME.Model;
using SGME.Repositories;

namespace SGME.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllUserTypeAsync();
        Task<UserType> GetUserTypeByIdAsync(int UserTypeId);
        Task CreateUserTypeAsync(UserType UserType);
        Task UpdateUserTypeAsync(UserType UserType);
        Task DeleteUserTypeAsync(int id);
        Task SoftDeleteUserTypeAsync(int UserTypeId);

    }

    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<IEnumerable<UserType>> GetAllUserTypeAsync()
        {
            return await _userTypeRepository.GetAllUserTypesAsync();
        }

        public async Task<UserType> GetUserTypeByIdAsync(int UserTypeId)
        {
            return await _userTypeRepository.GetUserTypeByIdAsync(UserTypeId);
        }

        public async Task CreateUserTypeAsync(UserType userType)
        {
            await _userTypeRepository.CreateUserTypeAsync(userType);
        }

        public async Task UpdateUserTypeAsync(UserType userType)
        {
            await _userTypeRepository.UpdateUserTypeAsync(userType);
        }

        public async Task DeleteUserTypeAsync(int UserTypeId)
        {
            await _userTypeRepository.DeleteUserTypeAsync(UserTypeId);
        }

        public async Task SoftDeleteUserTypeAsync(int UserTypeId)
        {
            await _userTypeRepository.SoftDeleteUserTypeAsync(UserTypeId);
        }
    }
}
