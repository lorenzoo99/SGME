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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Permissions>>> GetAllPermissions()
        {
            var Permissions = await _PermissionsService.GetAllPermissionsAsync();
            return Ok(Permissions);
        }

        [HttpGet("{PermissionsId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Permissions>> GetPermissionsById(int PermissionsId)
        {
            var Permissions = await _PermissionsService.GetPermissionsByIdAsync(PermissionsId);
            if (Permissions == null)
                return NotFound();

            return Ok(Permissions);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateUser(string PermissionName, string PermissionDescription, Permissions permissions)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _PermissionsService.CreatePermissionsAsync(PermissionName, PermissionDescription, permissions);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }


            return StatusCode(StatusCodes.Status201Created, "Permission created");
        }

            [HttpPut("{PermissionsId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> UpdatePermissions(int PermissionsId, string PermissionName, string PermissionDescription, Permissions permissions)
        {
            var existingContentUser = await _PermissionsService.GetPermissionsByIdAsync(PermissionsId);
            if (existingContentUser == null)
                return NotFound();
            try
            {

                await _PermissionsService.UpdatePermissionsAsync(PermissionsId, PermissionName, PermissionDescription, permissions);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpDelete("{PermissionsId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> DeletePermissions(int PermissionsId)
        {
                var Content = await _PermissionsService.GetPermissionsByIdAsync(PermissionsId);
                if (Content == null)
                    return NotFound();

                try
                {
                    await _PermissionsService.DeletePermissionsAsync(PermissionsId);
                    return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
                }
                catch (Exception e)
                {
                    return StatusCode(404, e?.Message);
                }
            }
        }
}