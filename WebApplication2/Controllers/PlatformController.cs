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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Platform>>> GetAllPlatform()
        {
            var Platform = await _PlatformService.GetAllPlatformsAsync();
            return Ok(Platform);
        }

        [HttpGet("{PlatformId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<User>> GetPlatformById(int PlatformId)
        {
            var Platform = await _PlatformService.GetPlatformByIdAsync(PlatformId);
            if (Platform == null)
                return NotFound();

            return Ok(Platform);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreatePlatform(string PlatformName, string PlatformDescription, Platform platform)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _PlatformService.CreatePlatformAsync(PlatformName, PlatformDescription, platform);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }


            return StatusCode(StatusCodes.Status201Created, "Platform created");
        }

        [HttpPut("{PlatformId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> UpdatePlatform(int PlatformId, string PlatformName, string PlatformDescription, Platform platform)
        {
            if (PlatformId != platform.PlatformID)
                return BadRequest();

            var existingPlatform = await _PlatformService.GetPlatformByIdAsync(PlatformId);
            if (existingPlatform == null)
                return NotFound();

            await _PlatformService.UpdatePlatformAsync(PlatformId, PlatformName, PlatformDescription, platform);
            return NoContent();
        }

        [HttpDelete("{PlatformId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> DeletePlatform(int PlatformId)
        {
            var Content = await _PlatformService.GetPlatformByIdAsync(PlatformId);
            if (Content == null)
                return NotFound();

            try
            {
            await _PlatformService.DeletePlatformAsync(PlatformId);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);

        }
    }
}
}