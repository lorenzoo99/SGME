
﻿using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;
=======



public interface IContentRepository
{
    Task<IEnumerable<Content>> GetAllContentAsync();
    Task<Content> GetContentByIdAsync(int id);
    Task CreateContentAsync(Content content);
    Task UpdateContentAsync(Content content);

    Task DeleteContentAsync(int id);

    Task SoftDeleteContentAsync(int id);

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

    public async Task<Content> GetContentByIdAsync(int id)
    {
        return await _context.Contents
            .FirstOrDefaultAsync(c => c.ContentId == id && !c.IsDeleted);
    }

    public async Task CreateContentAsync(Content content)
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

    public async Task UpdateContentAsync(Content content)
    {
        _context.Contents.Update(content);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContentAsync(int id)
    {
        var content = await _context.Contents.FindAsync(id);
        if (content != null)
        {
            content.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
        }
    }
}

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

