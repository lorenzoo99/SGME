using SGME.Model;

public interface IContentRepository
{
    Task<IEnumerable<Content>> GetAllContentAsync();
    Task<Content> GetContentByIdAsync(int id);
    Task CreateContentAsync(Content content);
    Task UpdateContentAsync(Content content);
    Task SoftDeleteContentAsync(int id);
}

public class ContentRepository : IContentRepository
{
    public Task CreateContentAsync(Content content)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Content>> GetAllContentAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Content> GetContentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SoftDeleteContentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateContentAsync(Content content)
    {
        throw new NotImplementedException();
    }
}
