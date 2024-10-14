using SGME.Model;
using SGME.Repositories;

namespace SGME.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllUserTypeAsync();
        Task<UserType> GetUserTypeByIdAsync(int UserTypeId);
        Task CreateUserTypeAsync(string Name, string UserTypeName, string UserTypeDescription, UserType userType);
        Task UpdateUserTypeAsync(int UserTypeId, string Name, string UserTypeName, string UserTypeDescription, UserType userType);
        Task DeleteUserTypeAsync(int UserTypeIdd);

        
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

        public async Task CreateUserTypeAsync(string Name, string UserTypeName, string UserTypeDescription, UserType userType)
        {
            await _userTypeRepository.CreateUserTypeAsync(Name, UserTypeName, UserTypeDescription, userType);
        }

        public async Task UpdateUserTypeAsync(int UserTypeId, string Name, string UserTypeName, string UserTypeDescription, UserType userType)
        {
            await _userTypeRepository.UpdateUserTypeAsync(UserTypeId, Name, UserTypeName, UserTypeDescription, userType);
        }

        public async Task DeleteUserTypeAsync(int UserTypeId)
        {
            await _userTypeRepository.DeleteUserTypeAsync(UserTypeId);
        }

       
    }
}
