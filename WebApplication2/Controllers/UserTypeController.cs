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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserType>>> GetAllUserType()
        {
            var UserType = await _UserTypeService.GetAllUserTypeAsync();
            return Ok(UserType);
        }

        [HttpGet("{UserTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserType>> GetUserTypeById(int UserTypeId)
        {
            var UserType = await _UserTypeService.GetUserTypeByIdAsync(UserTypeId);
            if (UserType == null)
                return NotFound();

            return Ok(UserType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateUserType(string Name, string UserTypeName, string UserTypeDescription, UserType userType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _UserTypeService.CreateUserTypeAsync(Name, UserTypeName, UserTypeDescription, userType);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }


            return StatusCode(StatusCodes.Status201Created, "UserType created");
        }

        [HttpPut("{UserTypeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> UpdateTypeUser(int UserTypeId, string Name, string UserTypeName, string UserTypeDescription, UserType userType)
        {
            var existingContentUser = await _UserTypeService.GetUserTypeByIdAsync(UserTypeId);
            if (existingContentUser == null)
                return NotFound();
            try
            {

                await _UserTypeService.UpdateUserTypeAsync(UserTypeId, Name, UserTypeName, UserTypeDescription, userType);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpDelete("{UserTypeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> DeleteUserType(int UserTypeId)
        {
            var Content = await _UserTypeService.GetUserTypeByIdAsync(UserTypeId);
            if (Content == null)
                return NotFound();

            try
            {
                await _UserTypeService.DeleteUserTypeAsync(UserTypeId);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);
            }
        }
    }
}