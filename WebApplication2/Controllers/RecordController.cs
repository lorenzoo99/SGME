using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGME.Model;
using SGME.Services;

namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordService _RecordService;

        public RecordController(IRecordService RecordService)
        {

            _RecordService = RecordService;
        }
        public async Task<ActionResult<IEnumerable<Record>>> GetAllRecord()
        {
            var Record = await _RecordService.GetAllRecordAsync();
            return Ok(Record);
        }

        public async Task<ActionResult<Record>> GetRecordById(int RecordId)
        {
            var Record = await _RecordService.GetRecordByIdAsync(RecordId); 
            if (Record != null)
                return Ok(Record);

            return NotFound();
        }

        public async Task<ActionResult> CreateRecord([FromBody] Record record)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _RecordService.CreateRecordAsync(record);
            return CreatedAtAction(nameof(GetRecordById), new { RecordId = record.RecordId }, record);
        }

        public async Task<ActionResult> UpdateRecord(int RecordId, [FromBody] Record record)
        {
            if (RecordId != record.RecordId)
                return BadRequest();

            var existingRecord = await _RecordService.GetRecordByIdAsync(RecordId);
            if (existingRecord == null)
                return NotFound();

            await _RecordService.GetRecordByIdAsync(RecordId);
            return NoContent();
        }

        public async Task<ActionResult> SoftDeleteRecord(int RecordId)
        {
            var Record = await _RecordService.GetRecordByIdAsync(RecordId);
            if (Record == null)
                return NotFound();

            await _RecordService.GetRecordByIdAsync(RecordId);
            return NoContent();

        }
    }
}
