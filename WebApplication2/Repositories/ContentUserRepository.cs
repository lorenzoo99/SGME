using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;


public interface IContentUserRepository
    {
        Task<IEnumerable<ContentUser>> GetAllContentUsersAsync();
        Task<ContentUser> GetContentUserByIdAsync(int ContentUserId);
        Task CreateContentUserAsync(string InteractionStatus, ContentUser contentUser);
        Task UpdateContentUserAsync(int ContentUserId, string InteractionStatus, ContentUser contentUser);
        Task DeleteContentUserAsync(int ContentUserId);
    
}

    public class ContentUserRepository : IContentUserRepository
    {
        private readonly TestContext _context;

        public ContentUserRepository(TestContext context)
        {
            _context = context;
        }

    public async Task<IEnumerable<ContentUser>> GetAllContentUsersAsync()
        {
            return await _context.ContentUsers
                .Where(cu => !cu.IsDeleted) // Excluye los eliminados
            .ToListAsync();
        }

        public async Task<ContentUser> GetContentUserByIdAsync(int ContentUserId)
        {
            return await _context.ContentUsers
                .FirstOrDefaultAsync(cu => cu.ContentUserID == ContentUserId && !cu.IsDeleted);
        }

        public async Task CreateContentUserAsync(string InteractionStatus, ContentUser contentUser)
        {
            try
            {
                await _context.ContentUsers.AddAsync(contentUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw; // Manejo de excepción opcional
            }
        }

        public async Task UpdateContentUserAsync(int ContentUserId, string InteractionStatus, ContentUser contentUser)
        {
            _context.ContentUsers.Update(contentUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContentUserAsync(int ContentUserId)
        {
            var contentUser = await _context.ContentUsers.FindAsync(ContentUserId);
            if (contentUser != null)
            {
                contentUser.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
        }
    }
    