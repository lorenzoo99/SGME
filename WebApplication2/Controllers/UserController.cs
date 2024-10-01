using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGME.Model;

namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {

            _UserService = UserService;
        }
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            var Users = await _UserService.GetAllUserAsync();
            return Ok(Users);
        }

        public async Task<ActionResult<User>> GetUserById(int UserId)
        {
            var User = await _UserService.GetUserByIdSync(UserId);
            if (User == null)
                return NotFound();

            return Ok(User);
        }

        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _UserService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { UserId = user.Id }, user);
        }

        public async Task<ActionResult> UpdateUser(int UserId, [FromBody] User user)
        {
            if (UserId != user.Id)
                return BadRequest();

            var existingUser = await _UserService.GetUserByIdSync(UserId);
            if (existingUser == null)
                return NotFound();

            await _UserService.UpdateUserAsync(user);
            return NoContent();
        }

        public async Task<ActionResult> SoftDeleteUser(int UserId)
        {
            var User = await _UserService.GetUserByIdSync(UserId);
            if (User == null)
                return NotFound();

            await _UserService.SoftDeleteUserAsync(UserId);
            return NoContent();

        }
    }
}
