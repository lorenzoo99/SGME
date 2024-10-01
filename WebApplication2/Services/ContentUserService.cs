using SGME.Model;

namespace SGME.Services
{
    public interface IContentUserService
    {
        Task<IEnumerable<ContentUser>> GetAllContentUsersAsync();
        Task<ContentUser> GetContentUserByIdAsync(int ContentUserid);
        Task CreateContentUserAsync(ContentUser contentUser);
        Task UpdateContentUserAsync(ContentUser contentUser);
        Task DeleteContentUserAsync(int ContentUserid);
    }

    public class ContentUserService : IContentUserService
    {
        private readonly IContentUserRepository _contentUserRepository;

        public ContentUserService(IContentUserRepository contentUserRepository)
        {
            _contentUserRepository = contentUserRepository;
        }

        public async Task<IEnumerable<ContentUser>> GetAllContentUsersAsync()
        {
            return await _contentUserRepository.GetAllContentUsersAsync();
        }

        public async Task<ContentUser> GetContentUserByIdAsync(int ContentUserId)
        {
            return await _contentUserRepository.GetContentUserByIdAsync(ContentUserId);
        }

        public async Task CreateContentUserAsync(ContentUser contentUser)
        {
            await _contentUserRepository.CreateContentUserAsync(contentUser);
        }

        public async Task UpdateContentUserAsync(ContentUser contentUser)
        {
            await _contentUserRepository.UpdateContentUserAsync(contentUser);
        }

        public async Task DeleteContentUserAsync(int ContentUserId)
        {
            await _contentUserRepository.DeleteContentUserAsync(ContentUserId);
        }
    }
}
