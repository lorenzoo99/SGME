using SGME.Model;

public interface IRecordService
{


    Task<IEnumerable<Record>> GetAllRecordAsync();
    Task<Record> GetRecordByIdAsync(int RecordId);
    Task CreateRecordAsync(Record record);
    Task UpdateRecordAsync(Record record);
    Task SoftDeleteRecordAsync(int RecordId);

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

    public async Task<Record> GetRecordByIdAsync(int RecordId)
    {
        return await _recordRepository.GetRecordByIdAsync(RecordId);
    }

    public async Task CreateRecordAsync(Record record)
    {
        await _recordRepository.CreateRecordAsync(record);
    }

    public async Task UpdateRecordAsync(Record record)
    {
        await _recordRepository.UpdateRecordAsync(record);
    }

    public async Task SoftDeleteRecordAsync(int RecordId)
    {
        await _recordRepository.SoftDeleteRecordAsync(RecordId);
    }

    public Task<IEnumerable<Record>> GetAllRecordAsync()
    {
        throw new NotImplementedException();
    }
}


   
