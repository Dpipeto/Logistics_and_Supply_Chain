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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePermissionXuserType([FromBody] PermissionXuserType permissionXuserType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _PermissionXuserTypeService.CreatePermissionXuserTypeAsync(permissionXuserType);
            return CreatedAtAction(nameof(GetPermissionXuserTypeById), new { id = permissionXuserType.Id }, permissionXuserType);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermissionXuserType(int id, [FromBody] PermissionXuserType permissionXuserType)
        {
            if (id != permissionXuserType.Id)
                return BadRequest();

            var existingPermissionXuserType = await _PermissionXuserTypeService.GetPermissionXuserTypeByIdAsync(id);
            if (existingPermissionXuserType == null)
                return NotFound();

            await _PermissionXuserTypeService.UpdatePermissionXuserTypeAsync(permissionXuserType);
            return NoContent();
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
