using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserTypes>>> GetAllUserTypes()
        {
            var userTypes = await _userTypeService.GetAllUserTypesAsync();
            return Ok(userTypes);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserTypes>> GetUserTypesById(int id)
        {
            var userTypes = await _userTypeService.GetUserTypesByIdAsync(id);
            if (userTypes == null)
                return NotFound();

            return Ok(userTypes);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateUserTypes([FromBody] UserTypes userTypes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _userTypeService.CreateUserTypesAsync(userTypes);
            return CreatedAtAction(nameof(GetUserTypesById), new { id = userTypes.Id }, userTypes);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserTypes(int id, [FromBody] UserTypes userTypes)
        {
            if (id != userTypes.Id)
                return BadRequest();

            var existingUserType = await _userTypeService.GetUserTypesByIdAsync(id);
            if (existingUserType == null)
                return NotFound();

            await _userTypeService.UpdateUserTypesAsync(userTypes);
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteUserTypes(int id)
        {
            var userTypes = await _userTypeService.GetUserTypesByIdAsync(id);
            if (userTypes == null)
                return NotFound();

            await _userTypeService.SoftDeleteUserTypesAsync(id);
            return NoContent();
        }
    }
}
