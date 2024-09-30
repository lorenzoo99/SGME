﻿using SGME.Model;

public interface IRecordService
{

    Task<IEnumerable<Record>> GetAllRecordsAsync();
    Task<Record> GetRecordByIdAsync(int id);
    Task CreateRecordAsync(Record record);
    Task UpdateRecordAsync(Record record);
    Task DeleteRecordAsync(int id);

    Task<IEnumerable<Record>> GetAllRecordAsync();
    Task<Record> GetRecordByIdAsync(int id);
    Task CreateRecordAsync(Record record);
    Task UpdateRecordAsync(Record record);
    Task SoftDeleteRecordAsync(int id);

}

public class RecordService : IRecordService
{

    private readonly IRecordRepository _recordRepository;

    public RecordService(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public async Task<IEnumerable<Record>> GetAllRecordsAsync()
    {
        return await _recordRepository.GetAllRecordsAsync();
    }

    public async Task<Record> GetRecordByIdAsync(int id)
    {
        return await _recordRepository.GetRecordByIdAsync(id);
    }

    public async Task CreateRecordAsync(Record record)
    {
        await _recordRepository.CreateRecordAsync(record);
    }

    public async Task UpdateRecordAsync(Record record)
    {
        await _recordRepository.UpdateRecordAsync(record);
    }

    public async Task DeleteRecordAsync(int id)
    {
        await _recordRepository.DeleteRecordAsync(id);

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
