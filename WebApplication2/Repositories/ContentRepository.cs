
﻿using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;

public interface IContentRepository
{
    Task<IEnumerable<Content>> GetAllContentAsync();
    Task<Content> GetContentByIdAsync(int ContentId);
    Task CreateContentAsync(string contents, string contentTitle, string contentType, Content content);
    Task UpdateContentAsync(int ContentId, string Contents, string ContentTitle, string ContentType, Content content);

    Task SoftDeleteContentAsync(int ContentId);

}

public class ContentRepository : IContentRepository
{

    private readonly TestContext _context;

    public ContentRepository(TestContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Content>> GetAllContentAsync()
    {
        return await _context.Contents
            .Where(c => !c.IsDeleted) // Excluye los eliminados
            .ToListAsync();
    }

    public async Task<Content> GetContentByIdAsync(int ContentId)
    {
        return await _context.Contents
            .FirstOrDefaultAsync(c => c.ContentID == ContentId && !c.IsDeleted);
    }

    public async Task CreateContentAsync(string Contents, string ContentTitle, string ContentType, Content content)
    {
        try
        {
            await _context.Contents.AddAsync(content);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw; // Manejo de excepción opcional
        }
    }

    public async Task UpdateContentAsync(int ContentId, string Contents, string ContentTitle, string ContentType, Content content)
    {
        _context.Contents.Update(content);
        await _context.SaveChangesAsync();
    }

    public async Task SoftDeleteContentAsync(int ContentId)
    {
        var content = await _context.Contents.FindAsync(ContentId);
        if (content != null)
        {
            content.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
        }
    }

   
}





