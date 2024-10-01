using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGME.Model;
using SGME.Services;

namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentUserController : ControllerBase
    {
        private readonly IContentUserService _ContentUserService;

        public ContentUserController(IContentUserService ContentUserService)
        {

            _ContentUserService = ContentUserService;
        }
        public async Task<ActionResult<IEnumerable<ContentUser>>> GetAllContentUser()
        {
            var ContentUser = await _ContentUserService.GetAllContentUsersAsync();
            return Ok(ContentUser);
        }

        public async Task<ActionResult<ContentUser>> GetContentUserById(int ContentUserId)
        {
            var ContentUser = await _ContentUserService.GetContentUserByIdAsync(ContentUserId);
            if (ContentUser == null)
                return NotFound();

            return Ok(ContentUser);
        }

        public async Task<ActionResult> CreateContentUser([FromBody] ContentUser contentUser)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            await _ContentUserService.CreateContentUserAsync(contentUser);
            return CreatedAtAction(nameof(GetContentUserById), new { ContentUserId = contentUser.ContentID }, contentUser);
        }

        public async Task<ActionResult> UpdateContentUser(int ContentUserId, [FromBody] ContentUser contentUser)
        {
            if (ContentUserId != contentUser.ContentUserID)
                return BadRequest();

            var existingContentUser = await _ContentUserService.GetContentUserByIdAsync(ContentUserId);
            if (existingContentUser == null)
                return NotFound();

            await _ContentUserService.UpdateContentUserAsync(contentUser);
            return NoContent();
        }

        public async Task<ActionResult> SoftDeleteContentUser(int ContentUserId)
        {
            var ContentUser = await _ContentUserService.GetContentUserByIdAsync(ContentUserId);
            if (ContentUser == null)
                return NotFound();

            await _ContentUserService.DeleteContentUserAsync(ContentUserId);
            return NoContent();

        }
    }
}