using SGME.Model;

public interface IRecordService
{
    Task<IEnumerable<Record>> GetAllRecordAsync();
    Task<Record> GetRecordByIdAsync(int id);
    Task CreateRecordAsync(Record record);
    Task UpdateRecordAsync(Record record);
    Task SoftDeleteRecordAsync(int id);
}

public class RecordService : IRecordService
{
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
