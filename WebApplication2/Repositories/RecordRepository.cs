
﻿using Microsoft.EntityFrameworkCore;
using SGME.Model;
using WebApplication2.Context;

public interface IRecordRepository
{
    Task<IEnumerable<Record>> GetAllRecordsAsync();
    Task<Record> GetRecordByIdAsync(int id);
    Task CreateRecordAsync(Record record);
    Task UpdateRecordAsync(Record record);
    Task DeleteRecordAsync(int id);


public interface IRecordRepository
{
    Task<IEnumerable<Record>> GetAllRecordAsync();
    Task<Record> GetRecordByIdAsync(int id);
    Task CreateRecordAsync(Record record);
    Task UpdateRecordAsync(Record record);
    Task SoftDeleteRecordAsync(int id);

}

public class RecordRepository : IRecordRepository
{

    private readonly TestContext _context;

    public RecordRepository(TestContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Record>> GetAllRecordsAsync()
    {
        return await _context.Records
            .Where(r => !r.IsDeleted) // Excluye los eliminados
            .ToListAsync();
    }

    public async Task<Record> GetRecordByIdAsync(int id)
    {
        return await _context.Records
            .FirstOrDefaultAsync(s => s.RecordId == id && !s.IsDeleted);
    }

    public async Task CreateRecordAsync(Record record)
    {
        try
        {
            await _context.Records.AddAsync(record);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw; // Manejo de excepción opcional
        }
    }

    public async Task UpdateRecordAsync(Record record)
    {
        _context.Records.Update(record);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRecordAsync(int id)
    {
        var record = await _context.Records.FindAsync(id);
        if (record != null)
        {
            record.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
        }

    public Task CreateRecordAsync(Record record)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Record>> GetAllRecordAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Record> GetRecordByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SoftDeleteRecordAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRecordAsync(Record record)
    {
        throw new NotImplementedException();

    }
}