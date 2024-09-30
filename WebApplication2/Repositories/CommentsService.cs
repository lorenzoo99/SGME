namespace SGME.Repositories
using SGME.Model;
public interface ICommentsService
    {
        Task<IEnumerable<Comments>> GetAllCommentsAsync();
        Task<Comments> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(Comments comment);
        Task UpdateCommentAsync(Comments comment);
        Task DeleteCommentAsync(int id);
    }

public class CommentsService : ICommentsService
{
    private readonly ICommentsRepository _commentsRepository;

    public CommentsService(ICommentsRepository commentsRepository)
    {
        _commentsRepository = commentsRepository;
    }

    public async Task<IEnumerable<Comments>> GetAllCommentsAsync()
    {
        return await _commentsRepository.GetAllCommentsAsync();
    }

    public async Task<Comments> GetCommentByIdAsync(int id)
    {
        return await _commentsRepository.GetCommentByIdAsync(id);
    }

    public async Task CreateCommentAsync(Comments comment)
    {
        await _commentsRepository.CreateCommentAsync(comment);
    }

    public async Task UpdateCommentAsync(Comments comment)
    {
        await _commentsRepository.UpdateCommentAsync(comment);
    }

    public async Task DeleteCommentAsync(int id)
    {
        await _commentsRepository.DeleteCommentAsync(id);
    }
}
