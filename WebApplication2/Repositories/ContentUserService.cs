using SGME.Model;

namespace SGME.Repositories
{
    public interface IContentUserService
    {
        Task<IEnumerable<ContentUser>> GetAllContentUsersAsync();
        Task<ContentUser> GetContentUserByIdAsync(int id);
        Task CreateContentUserAsync(ContentUser contentUser);
        Task UpdateContentUserAsync(ContentUser contentUser);
        Task DeleteContentUserAsync(int id);
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

        public async Task<ContentUser> GetContentUserByIdAsync(int id)
        {
            return await _contentUserRepository.GetContentUserByIdAsync(id);
        }

        public async Task CreateContentUserAsync(ContentUser contentUser)
        {
            await _contentUserRepository.CreateContentUserAsync(contentUser);
        }

        public async Task UpdateContentUserAsync(ContentUser contentUser)
        {
            await _contentUserRepository.UpdateContentUserAsync(contentUser);
        }

        public async Task DeleteContentUserAsync(int id)
        {
            await _contentUserRepository.DeleteContentUserAsync(id);
        }
    }
}
