using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;


public interface IContentUserRepository
    {
        Task<IEnumerable<ContentUser>> GetAllContentUsersAsync();
        Task<ContentUser> GetContentUserByIdAsync(int id);
        Task CreateContentUserAsync(ContentUser contentUser);
        Task UpdateContentUserAsync(ContentUser contentUser);
        Task DeleteContentUserAsync(int id);
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

        public async Task<ContentUser> GetContentUserByIdAsync(int id)
        {
            return await _context.ContentUsers
                .FirstOrDefaultAsync(cu => cu.ContentUserID == id && !cu.IsDeleted);
        }

        public async Task CreateContentUserAsync(ContentUser contentUser)
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

        public async Task UpdateContentUserAsync(ContentUser contentUser)
        {
            _context.ContentUsers.Update(contentUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContentUserAsync(int id)
        {
            var contentUser = await _context.ContentUsers.FindAsync(id);
            if (contentUser != null)
            {
                contentUser.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
        }
    }
    