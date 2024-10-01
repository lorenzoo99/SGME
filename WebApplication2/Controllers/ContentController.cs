using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.VisualBasic;
using SGME.Model;
using SGME.Services;

namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _ContentService;

        public ContentController(IContentService ContentService)
        {

            _ContentService = ContentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Content>>> GetAllContent()
        {
            var Content = await _ContentService.GetAllContentAsync();
            return Ok(Content);
        }

        [HttpGet("{ContentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Content>> GetContentById(int ContentId)
        {
            var Content = await _ContentService.GetContentByIdAsync(ContentId);
            if (Content == null)
                return NotFound();

            return Ok(Content);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateContent(string Contents, string ContentTitle, string ContentType, Content content)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _ContentService.CreateContentAsync(Contents, ContentTitle, ContentType, content);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }


            return StatusCode(StatusCodes.Status201Created, "Content created");
        }

        [HttpPut("{ContentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> UpdateContentUser(int ContentId, string Contents, string ContentTitle, string ContentType, Content content)
        {

            var existingContentUser = await _ContentService.GetContentByIdAsync(ContentId);
            if (existingContentUser == null)
                return NotFound();

            try
            {

                await _ContentService.UpdateContentAsync(ContentId, Contents, ContentTitle, ContentType, content);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpDelete("{ContentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> SoftDeleteContent(int ContentId)
        {
            var Content = await _ContentService.GetContentByIdAsync(ContentId);
            if (Content == null)
                return NotFound();

            try
            {
                await _ContentService.SoftDeleteContentAsync(ContentId);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);
            }
        }
    }
}