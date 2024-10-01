using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGME.Model;
using SGME.Services;

namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
   
    {
        private readonly IUserTypeService _UserTypeService;

        public UserTypeController(IUserTypeService UserTypeService)
        {

            _UserTypeService = UserTypeService;
        }
        public async Task<ActionResult<IEnumerable<UserType>>> GetAllUserType()
        {
            var UserType = await _UserTypeService.GetAllUserTypeAsync();
            return Ok(UserType);
        }

        public async Task<ActionResult<UserType>> GetUserTypeById(int UserTypeId)
        {
            var UserType = await _UserTypeService.GetUserTypeByIdAsync(UserTypeId);
            if (UserType == null)
                return NotFound();

            return Ok(UserType);
        }

        public async Task<ActionResult> CreateUserType([FromBody] UserType userType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _UserTypeService.CreateUserTypeAsync(userType);
            return CreatedAtAction(nameof(GetUserTypeById), new { UserTypeId = userType.Id }, userType);
        }

        public async Task<ActionResult> UpdateTypeUser(int UserTypeId, [FromBody] UserType userType)
        {
            if (UserTypeId != userType.Id)
                return BadRequest();

            var existingUserType = await _UserTypeService.GetUserTypeByIdAsync(UserTypeId);
            if (existingUserType == null)
                return NotFound();

            await _UserTypeService.UpdateUserTypeAsync(userType);
            return NoContent();
        }

        public async Task<ActionResult> SoftDeleteUserType(int UserTypeId)
        {
            var UserType = await _UserTypeService.GetUserTypeByIdAsync(UserTypeId);
            if (UserType == null)
                return NotFound();

            await _UserTypeService.SoftDeleteUserTypeAsync(UserTypeId);
            return NoContent();

        }
    }
}