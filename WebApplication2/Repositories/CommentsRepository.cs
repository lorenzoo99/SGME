using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;

namespace SGME.Repositories
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comments>> GetAllCommentsAsync();
        Task<Comments> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(Comments comment);
        Task UpdateCommentAsync(Comments comment);
        Task DeleteCommentAsync(int id);
    }

    public class CommentsRepository : ICommentsRepository
    {
        private readonly TestContext _context;

        public CommentsRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comments>> GetAllCommentsAsync()
        {
            return await _context.Comment
                .Where(c => !c.IsDeleted) // Excluye los eliminados
                .ToListAsync();
        }

        public async Task<Comments> GetCommentByIdAsync(int id)
        {
            return await _context.Comment
                .FirstOrDefaultAsync(c => c.CommentsId == id && !c.IsDeleted);
        }

        public async Task CreateCommentAsync(Comments comment)
        {
            try
            {
                await _context.Comment.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw; // Manejo de excepción opcional
            }
        }

        public async Task UpdateCommentAsync(Comments comment)
        {
            _context.Comment.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment != null)
            {
                comment.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
        }
    }
}
