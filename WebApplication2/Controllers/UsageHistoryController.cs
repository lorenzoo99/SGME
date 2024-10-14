using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGME.Model;
using SGME.Services;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UsageHistory>>> GetAllUsageHistory()
        {
            var UsageHistory = await _usageHistoryService.GetAllUsageHistoriesAsync();
            return Ok(UsageHistory);
        }

        [HttpGet("{UsageHistoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<UsageHistory>> GetUsageHistoryById(int UsageHistoryId)
        {
            var UsageHistory = await _usageHistoryService.GetUsageHistoryByIdAsync(UsageHistoryId);
            if (UsageHistory == null)
                return NotFound();

            return Ok(UsageHistory);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateUsageHistory(int ViewDuration, UsageHistory usageHistory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _usageHistoryService.CreateUsageHistoryAsync(ViewDuration, usageHistory);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }


            return StatusCode(StatusCodes.Status201Created, "Usage History created");
        }

        [HttpPut("{UsageHistoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> UpdateUsageHistory(int UsageHistoryId, int ViewDuration, UsageHistory usageHistory)
        {
            var existingContentUser = await _usageHistoryService.GetUsageHistoryByIdAsync(UsageHistoryId);
            if (existingContentUser == null)
                return NotFound();
            try
            {

                await _usageHistoryService.UpdateUsageHistoryAsync(UsageHistoryId, ViewDuration, usageHistory);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpDelete("{UsageHistoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> DeleteUsageHistory(int UsageHistoryId)
        {
            
                var Content = await _usageHistoryService.GetUsageHistoryByIdAsync(UsageHistoryId);
                if (Content == null)
                return NotFound();

                try
                {
                    await _usageHistoryService.DeleteUsageHistoryAsync(UsageHistoryId);
                    return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
                }
                catch (Exception e)
                {
                    return StatusCode(404, e?.Message);
                }
        }
    }
}