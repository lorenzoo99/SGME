using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGME.Model;
using SGME.Services;

namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsageHistoryController : ControllerBase
    {
        private readonly IUsageHistoryService _usageHistoryService;

        public UsageHistoryController(IUsageHistoryService usageHistoryService)
        {

            _usageHistoryService = usageHistoryService;
        }
        public async Task<ActionResult<IEnumerable<UserType>>> GetAllUsageHistory()
        {
            var UsageHistory = await _usageHistoryService.GetAllUsageHistoriesAsync();
            return Ok(UsageHistory);
        }

        public async Task<ActionResult<UserType>> GetUsageHistoryById(int UsageHistoryId)
        {
            var UsageHistory = await _usageHistoryService.GetUsageHistoryByIdAsync(UsageHistoryId);
            if (UsageHistory == null)
                return NotFound();

            return Ok(UsageHistory);
        }

        public async Task<ActionResult> CreateUsageHistory([FromBody] UserType usageHistory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usageHistoryService.CreateUsageHistoryAsync(usageHistory);
            return CreatedAtAction(nameof(GetUsageHistoryById), new { UsageHistoryId = usageHistory.Id }, usageHistory);
        }

        public async Task<ActionResult> UpdateUsageHistory(int UsageHistoryId, [FromBody] UserType usageHistory)
        {
            if (UsageHistoryId != usageHistory.Id)
                return BadRequest();

            var existingUsageHistory = await _usageHistoryService.GetUsageHistoryByIdAsync(UsageHistoryId);
            if (existingUsageHistory == null)
                return NotFound();

            await _usageHistoryService.GetUsageHistoryByIdAsync(UsageHistoryId);
            return NoContent();
        }

        public async Task<ActionResult> SoftDeleteUsageHistory(int UsageHistoryId)
        {
            var UsageHistory = await _usageHistoryService.GetUsageHistoryByIdAsync(UsageHistoryId);
            if (UsageHistory == null)
                return NotFound();

            await _usageHistoryService.GetUsageHistoryByIdAsync(UsageHistoryId);
            return NoContent();

        }
    }
}