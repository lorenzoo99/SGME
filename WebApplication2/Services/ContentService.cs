using SGME.Model;
namespace SGME.Services;
public interface IContentService
{
    Task<IEnumerable<Content>> GetAllContentAsync();
    Task<Content> GetContentByIdAsync(int ContentId);
    Task UpdateContentAsync(int ContentId, string Contents, string ContentTitle, string ContentType, Content content);
    Task SoftDeleteContentAsync(int ContentId);
    Task CreateContentAsync(string Contents, string ContentTitle, string ContentType, Content content);
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

    public async Task<Content> GetContentByIdAsync(int ContentId)
    {
        return await _contentRepository.GetContentByIdAsync(ContentId);
    }

    public async Task CreateContentAsync(string Contents, string ContentTitle, string ContentType, Content content)
    {
        await _contentRepository.CreateContentAsync(Contents, ContentTitle, ContentType, content);
    }

    public async Task UpdateContentAsync(int ContentId, string Contents, string ContentTitle, string ContentType, Content content)
    {
        await _contentRepository.UpdateContentAsync(ContentId, Contents, ContentTitle, ContentType, content);
    }


    public async Task SoftDeleteContentAsync(int ContentId)
    {
        await _contentRepository.SoftDeleteContentAsync(ContentId);

    }

}

