using Microsoft.AspNetCore.Mvc;
using SGME.Model;
using SGME.Services;

namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _CommentsService;

        public CommentsController(ICommentsService CommentsService)
        {

            _CommentsService = CommentsService;
        }
        public async Task<ActionResult<IEnumerable<Comments>>> GetAllComments()
        {
            var Comments = await _CommentsService.GetAllCommentsAsync();
            return Ok(Comments);
        }

        public async Task<ActionResult<Comments>> GetCommentsById(int CommentsId)
        {
            var Comments = await _CommentsService.GetCommentByIdAsync(CommentsId);
            if (Comments == null)
                return NotFound();

            return Ok(Comments);
        }

        public async Task<ActionResult> CreateComments([FromBody] Comments comments)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _CommentsService.CreateCommentAsync(comments);
            return CreatedAtAction(nameof(GetCommentsById), new { Comments = comments.CommentsId }, comments);
        }

        public async Task<ActionResult> UpdateComments(int CommentsId, [FromBody] Comments comments)
        {
            if (CommentsId != comments.CommentsId)
                return BadRequest();

            var existingComments = await _CommentsService.GetCommentByIdAsync(CommentsId);
            if (existingComments == null)
                return NotFound();

            await _CommentsService.UpdateCommentAsync(comments);
            return NoContent();
        }

        public async Task<ActionResult> SoftDeleteComments(int CommentsId)
        {
            var Comments = await _CommentsService.GetCommentByIdAsync(CommentsId);
            if (Comments == null)
                return NotFound();

            await _CommentsService.DeleteCommentAsync(CommentsId);
            return NoContent();

        }
    }
}
