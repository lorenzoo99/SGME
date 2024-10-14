using SGME.Model;

namespace SGME.Services
{
    public interface IContentUserService
    {
        Task<IEnumerable<ContentUser>> GetAllContentUsersAsync();
        Task<ContentUser> GetContentUserByIdAsync(int ContentUserid);
        Task UpdateContentUserAsync(int ContentUserId, string InteractionStatus, ContentUser contentUser);
        Task DeleteContentUserAsync(int ContentUserid);
        Task CreateContentUserAsync(string interactionStatus, ContentUser contentUser);
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

        public async Task CreateContentUserAsync(string interactionStatus, ContentUser contentUser)
        {
            await _contentUserRepository.CreateContentUserAsync(interactionStatus, contentUser);
        }
        
        public async Task UpdateContentUserAsync(int ContentUserId, string InteractionStatus, ContentUser contentUser)
        {
            await _contentUserRepository.UpdateContentUserAsync(ContentUserId, InteractionStatus, contentUser);
        }

        public async Task DeleteContentUserAsync(int ContentUserId)
        {
            await _contentUserRepository.DeleteContentUserAsync(ContentUserId);
        }
    }
}
