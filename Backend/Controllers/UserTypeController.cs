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
            var user_Types = await _userTypeService.GetAllUserTypesAsync();
            return Ok(user_Types);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserTypes>> GetUserTypesById(int id)
        {
            var user_Types = await _userTypeService.GetUserTypesByIdAsync(id);
            if (user_Types == null)
                return NotFound();

            return Ok(user_Types);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateUserTypes([FromBody] UserTypes user_Types)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _userTypeService.CreateUserTypesAsync(user_Types);
            return CreatedAtAction(nameof(GetUserTypesById), new { id = user_Types.Id }, user_Types);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserTypes(int id, [FromBody] UserTypes user_Types)
        {
            if (id != user_Types.Id)
                return BadRequest();

            var existingUserType = await _userTypeService.GetUserTypesByIdAsync(id);
            if (existingUserType == null)
                return NotFound();

            await _userTypeService.UpdateUserTypesAsync(user_Types);
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteUserTypes(int id)
        {
            var user_Types = await _userTypeService.GetUserTypesByIdAsync(id);
            if (user_Types == null)
                return NotFound();

            await _userTypeService.SoftDeleteUserTypesAsync(id);
            return NoContent();
        }
    }
}
