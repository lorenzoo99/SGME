using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGME.Model;
using SGME.Services;

namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionPerUserTypeController : ControllerBase
    {
        private readonly IPermissionPerUserTypeService _PermissionPerUserTypeService;

        public PermissionPerUserTypeController(IPermissionPerUserTypeService PermissionPerUserTypeService)
        {

            _PermissionPerUserTypeService = PermissionPerUserTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<PermissionPerUserType>>>GetAllPermissionPerUserType()
        {
            var PermissionPerUserType = await _PermissionPerUserTypeService.GetAllPermissionPerUserTypeAsync();
            return Ok(PermissionPerUserType);
        }

        [HttpGet("{UserType,PermissionPerUserTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PermissionPerUserType>> GetPermissionPerUserTypeById(int UserTypeId, int PermissionPerUserTypeId)
        {
            var PermissionPerUserType = await _PermissionPerUserTypeService.GetPermissionPerUserTypeByIdAsync(UserTypeId, PermissionPerUserTypeId);
            if (PermissionPerUserType == null)
                return NotFound();

            return Ok(PermissionPerUserType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreatePermissionPerUserType(int UserTypeID, PermissionPerUserType permissionPerUserType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _PermissionPerUserTypeService.CreatePermissionPerUserTypeAsync(UserTypeID, permissionPerUserType);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }


            return StatusCode(StatusCodes.Status201Created, "PermissionPerUserType created");
        }

        [HttpPut("{UserType,PermissionPerUserTypeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> UpdatePermissionPerUserType(int UserTypeId, int PermissionPerUserTypeId, PermissionPerUserType permissionPerUserType)
        {
            var existingContentUser = await _PermissionPerUserTypeService.GetPermissionPerUserTypeByIdAsync(UserTypeId, PermissionPerUserTypeId);
            if (existingContentUser == null)
                return NotFound();
            try
            {

                await _PermissionPerUserTypeService.UpdatePermissionPerUserTypeAsync(UserTypeId, PermissionPerUserTypeId, permissionPerUserType);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }
        [HttpDelete("{int UserTypeId,int PermissionPerUserTypeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> DeletePermissionPerUserType(int UserTypeId, int PermissionPerUserTypeId)
        {
            var Content = await _PermissionPerUserTypeService.GetPermissionPerUserTypeByIdAsync(UserTypeId, PermissionPerUserTypeId);
            if (Content == null)
                return NotFound();

            try
            {
                await _PermissionPerUserTypeService.DeletePermissionPerUserTypeAsync(UserTypeId, PermissionPerUserTypeId);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);

            }
        }
    }
}