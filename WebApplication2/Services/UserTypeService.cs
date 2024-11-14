using SGME.Model;
using SGME.Repositories;

namespace SGME.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllUserTypeAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(string name);
        Task UpdateUserTypeAsync(int id, string name);
        Task SoftDeleteUserTypeAsync(int id);
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

        public async Task CreateUserTypeAsync(string name)
        {
            await _userTypeRepository.CreateUserTypeAsync(name);
        }

        public async Task UpdateUserTypeAsync(int id, string name)
        {

            try
            {
                await _userTypeRepository.UpdateUserTypeAsync(id, name);

            }
            catch (Exception e)
            {

                throw;

            }
        }

        public async Task SoftDeleteUserTypeAsync(int id)
        {
            await _userTypeRepository.SoftDeleteUserTypeAsync(id);
        }


    }
}
