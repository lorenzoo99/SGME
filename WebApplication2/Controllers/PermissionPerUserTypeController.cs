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
        public async Task<ActionResult<IEnumerable<PermissionPerUserType>>> GetAllPermissionPerUserType()
        {
            var PermissionPerUserType = await _PermissionPerUserTypeService.GetAllPermissionsPerUserTypeAsync();
            return Ok(PermissionPerUserType);
        }

        public async Task<ActionResult<PermissionPerUserType>> GetPermissionPerUserTypeById(int UserType,int PermissionPerUserTypeId)
        {
            var PermissionPerUserType = await _PermissionPerUserTypeService.GetPermissionPerUserTypeByIdAsync(UserType,PermissionPerUserTypeId);
            if (PermissionPerUserType == null)
                return NotFound();

            return Ok(PermissionPerUserType);
        }

        public async Task<ActionResult> CreatePermissionPerUserType([FromBody] PermissionPerUserType permissionPerUserType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _PermissionPerUserTypeService.CreatePermissionPerUserTypeAsync(permissionPerUserType);
            return CreatedAtAction(nameof(GetPermissionPerUserTypeById), new { PermissionPerUserTypeId = permissionPerUserType.PermissionID }, permissionPerUserType);
        }

        public async Task<ActionResult> UpdatePermissionPerUserType(int UserTypeId,int PermissionPerUserTypeId, [FromBody] PermissionPerUserType permissionPerUserType)
        {
            if (PermissionPerUserTypeId != permissionPerUserType.PermissionPerUserTypeID)
                return BadRequest();

            var existingPermissionPerUserType = await _PermissionPerUserTypeService.GetPermissionPerUserTypeByIdAsync(UserTypeId,PermissionPerUserTypeId);
            if (existingPermissionPerUserType == null)
                return NotFound();

            await _PermissionPerUserTypeService.UpdatePermissionPerUserTypeAsync(permissionPerUserType);
            return NoContent();
        }

        public async Task<ActionResult> DeletePermissionPerUserType(int UserTypeId,int PermissionPerUserTypeId)
        {
            var PermissionPerUserType = await _PermissionPerUserTypeService.GetPermissionPerUserTypeByIdAsync(UserTypeId, PermissionPerUserTypeId);
            if (PermissionPerUserType == null)
                return NotFound();

            await _PermissionPerUserTypeService.DeletePermissionPerUserTypeAsync(UserTypeId, PermissionPerUserTypeId);
            return NoContent();

        }
    }
}