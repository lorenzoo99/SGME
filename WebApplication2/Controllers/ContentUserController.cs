using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContentUser>>> GetAllContentUser()
        {
            var ContentUser = await _ContentUserService.GetAllContentUsersAsync();
            return Ok(ContentUser);
        }

        [HttpGet("{ContentUserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ContentUser>> GetContentUserById(int ContentUserId)
        {
            var ContentUser = await _ContentUserService.GetContentUserByIdAsync(ContentUserId);
            if (ContentUser == null)
                return NotFound();

            return Ok(ContentUser);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateContentUser(string InteractionStatus, ContentUser contentUser)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            try
            {
                await _ContentUserService.CreateContentUserAsync(InteractionStatus, contentUser);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }


            return StatusCode(StatusCodes.Status201Created, "ContentUser created");
        }

        [HttpPut("{ContentUserId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> UpdateContentUser(int ContentUserId, string InteractionStatus, ContentUser contentUser)
        {
            if (ContentUserId != contentUser.ContentUserID)
                return BadRequest();

            var existingContentUser = await _ContentUserService.GetContentUserByIdAsync(ContentUserId);
            if (existingContentUser == null)
                return NotFound();
            try
            {

                await _ContentUserService.UpdateContentUserAsync(ContentUserId, InteractionStatus, contentUser);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpDelete("{ContentUserId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> DeleteContentUser(int ContentUserId)
        {
            var Content = await _ContentUserService.GetContentUserByIdAsync(ContentUserId);
            if (Content == null)
                return NotFound();

            try
            {
            await _ContentUserService.DeleteContentUserAsync(ContentUserId);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);

        }
    }
}
}

