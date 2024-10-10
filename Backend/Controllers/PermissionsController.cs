using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionsService _PermissionsService;

        public PermissionsController(IPermissionsService PermissionsService)
        {
            _PermissionsService = PermissionsService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Permissions>>> GetAllPermissions()
        {
            var permissions = await _PermissionsService.GetAllPermissionsAsync();
            return Ok(permissions);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Permissions>> GetPermissionsById(int id)
        {
            var permissions = await _PermissionsService.GetPermissionsByIdAsync(id);
            if (permissions == null)
                return NotFound();

            return Ok(permissions);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePermissions(string permission)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _PermissionsService.CreatePermissionsAsync(permission);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }
            return StatusCode(StatusCodes.Status201Created, "Permission created succesfully");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermissions(int id, string permission)
        {
            var existingPermissions = await _PermissionsService.GetPermissionsByIdAsync(id);
            if (existingPermissions == null)
                return NotFound();

            try
            {
                await _PermissionsService.UpdatePermissionsAsync(id, permission);
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
        public async Task<IActionResult> SoftDeletePermissions(int id)
        {
            var permissions = await _PermissionsService.GetPermissionsByIdAsync(id);
            if (permissions == null)
                return NotFound();

            await _PermissionsService.SoftDeletePermissionsAsync(id);
            return NoContent();
        }
    }
}
