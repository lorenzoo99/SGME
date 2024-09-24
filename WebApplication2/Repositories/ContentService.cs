using SGME.Model;

public interface IContentService
{
    Task<IEnumerable<Content>> GetAllContentAsync();
    Task<Content> GetContentByIdAsync(int id);
    Task CreateContentAsync(Content content);
    Task UpdateContentAsync(Content content);
    Task DeleteContentAsync(int id);
}

public class ContentService : IContentService
{
    private readonly IContentRepository _contentRepository;

    public ContentService(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public async Task<IEnumerable<Content>> GetAllContentAsync()
    {
        return await _contentRepository.GetAllContentAsync();
    }

    public async Task<Content> GetContentByIdAsync(int id)
    {
        return await _contentRepository.GetContentByIdAsync(id);
    }

    public async Task CreateContentAsync(Content content)
    {
        await _contentRepository.CreateContentAsync(content);
    }

    public async Task UpdateContentAsync(Content content)
    {
        await _contentRepository.UpdateContentAsync(content);
    }

    public async Task DeleteContentAsync(int id)
    {
        await _contentRepository.DeleteContentAsync(id);
    }
}

