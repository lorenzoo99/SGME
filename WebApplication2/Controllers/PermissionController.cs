using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGME.Model;

namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionsService _PermissionsService;

        public PermissionController(IPermissionsService PermissionsService)
        {

            _PermissionsService = PermissionsService;
        }
        public async Task<ActionResult<IEnumerable<Permissions>>> GetAllPermissions()
        {
            var Permissions = await _PermissionsService.GetAllPermissionsAsync();
            return Ok(Permissions);
        }

        public async Task<ActionResult<Permissions>> GetPermissionsById(int PermissionsId)
        {
            var Permissions = await _PermissionsService.GetPermissionsByIdAsync(PermissionsId);
            if (Permissions == null)
                return NotFound();

            return Ok(Permissions);
        }

        public async Task<ActionResult> CreateUser([FromBody] Permissions permissions)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _PermissionsService.CreatePermissionsAsync(permissions);
            return CreatedAtAction(nameof(GetPermissionsById), new { PermissionsId = permissions.PermissionID }, permissions);
        }

        public async Task<ActionResult> UpdatePermissions(int PermissionsId, [FromBody] Permissions permissions)
        {
            if (PermissionsId != permissions.PermissionID)
                return BadRequest();

            var existingPermissions = await _PermissionsService.GetPermissionsByIdAsync(PermissionsId);
            if (existingPermissions == null)
                return NotFound();

            await _PermissionsService.UpdatePermissionsAsync(permissions);
            return NoContent();
        }

        public async Task<ActionResult> SoftDeletePermissions(int PermissionsId)
        {
            var Permissions = await _PermissionsService.GetPermissionsByIdAsync(PermissionsId);
            if (Permissions == null)
                return NotFound();

            await _PermissionsService.SoftDeletePermissionsAsync(PermissionsId);
            return NoContent();

        }
    }
}