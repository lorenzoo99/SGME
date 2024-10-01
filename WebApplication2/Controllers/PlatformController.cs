using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGME.Model;
using System;

namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _PlatformService;

        public PlatformController(IPlatformService PlatformService)
        {

            _PlatformService = PlatformService;
        }
        public async Task<ActionResult<IEnumerable<Platform>>> GetAllPlatform()
        {
            var Platform = await _PlatformService.GetAllPlatformsAsync();
            return Ok(Platform);
        }

        public async Task<ActionResult<User>> GetPlatformById(int PlatformId)
        {
            var Platform = await _PlatformService.GetPlatformByIdAsync(PlatformId);
            if (Platform == null)
                return NotFound();

            return Ok(Platform);
        }

        public async Task<ActionResult> CreatePlatform([FromBody] Platform Platform)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _PlatformService.CreatePlatformAsync(Platform);
            return CreatedAtAction(nameof(GetPlatformById), new { PlatformId = Platform.PlatformID }, Platform);
        }

        public async Task<ActionResult> UpdatePlatform(int PlatformId, [FromBody] Platform platform)
        {
            if (PlatformId != platform.PlatformID)
                return BadRequest();

            var existingPlatform = await _PlatformService.GetPlatformByIdAsync(PlatformId);
            if (existingPlatform == null)
                return NotFound();

            await _PlatformService.UpdatePlatformAsync(platform);
            return NoContent();
        }

        public async Task<ActionResult> DeletePlatform(int PlatformId)
        {
            var Platform = await _PlatformService.GetPlatformByIdAsync(PlatformId);
            if (Platform == null)
                return NotFound();

            await _PlatformService.DeletePlatformAsync(PlatformId);
            return NoContent();

        }
    }
}