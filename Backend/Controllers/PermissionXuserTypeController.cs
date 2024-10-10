using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionXuserTypeController : ControllerBase
    {
        private readonly IPermissionXuserTypeService _PermissionXuserTypeService;

        public PermissionXuserTypeController(IPermissionXuserTypeService PermissionXuserTypeService)
        {
            _PermissionXuserTypeService = PermissionXuserTypeService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PermissionXuserType>>> GetAllPermissionXuserType()
        {
            var permissionXuserType = await _PermissionXuserTypeService.GetAllPermissionXuserTypeAsync();
            return Ok(permissionXuserType);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermissionXuserType>> GetPermissionXuserTypeById(int id)
        {
            var permissionXuserType = await _PermissionXuserTypeService.GetPermissionXuserTypeByIdAsync(id);
            if (permissionXuserType == null)
                return NotFound();

            return Ok(permissionXuserType);

        }
        // validate if a user has permission
        [HttpGet("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> ValidatePermission(int userTypesId, int permissionsId)
        {
            bool hasPermission = await _PermissionXuserTypeService.HasPermissionAsync(userTypesId, permissionsId);

            if (hasPermission)
            {
                return Ok(new { Message = "User has the required permission." });
            }

            return StatusCode(StatusCodes.Status403Forbidden, "User does not have the required permission.");
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePermissionXuserType(int userTypesId, int permissionsId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _PermissionXuserTypeService.CreatePermissionXuserTypeAsync(userTypesId, permissionsId);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }

            return StatusCode(StatusCodes.Status201Created, "Permission UserType created successfully.");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermissionXuserType(int id, int userTypesId, int permissionsId)
        {
            var existingPermissionUserType = await _PermissionXuserTypeService.GetPermissionXuserTypeByIdAsync(id);
            if (existingPermissionUserType == null) return NotFound();

            try
            {
                await _PermissionXuserTypeService.UpdatePermissionXuserTypeAsync(id, userTypesId, permissionsId);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePermissionXuserType(int id)
        {
            var permissionXuserType = await _PermissionXuserTypeService.GetPermissionXuserTypeByIdAsync(id);
            if (permissionXuserType == null)
                return NotFound();

            await _PermissionXuserTypeService.SoftDeletePermissionXuserTypeAsync(id);
            return NoContent();
        }
    }
}
