using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<Content>>> GetAllContent()
        {
            var Content = await _ContentService.GetAllContentAsync();
            return Ok(Content);
        }

        public async Task<ActionResult<Content>> GetContentById(int ContentId)
        {
            var Content = await _ContentService.GetContentByIdAsync(ContentId);
            if (Content == null)
                return NotFound();

            return Ok(Content);
        }

        public async Task<ActionResult> CreateContent([FromBody] Content content)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _ContentService.CreateContentAsync(content);
            return CreatedAtAction(nameof(GetContentById), new { ContentId = content.ContentID }, content);
        }

        public async Task<ActionResult> UpdateContent(int ContentId, [FromBody] Content content)
        {
            if (ContentId != content.ContentID)
                return BadRequest();

            var existingContent = await _ContentService.GetContentByIdAsync(ContentId);
            if (existingContent == null)
                return NotFound();

            await _ContentService.UpdateContentAsync(content);
            return NoContent();
        }

        public async Task<ActionResult> SoftDeleteContent(int ContentId)
        {
            var Content = await _ContentService.GetContentByIdAsync(ContentId);
            if (Content == null)
                return NotFound();

            await _ContentService.SoftDeleteContentAsync(ContentId);
            return NoContent();

        }
    }
}