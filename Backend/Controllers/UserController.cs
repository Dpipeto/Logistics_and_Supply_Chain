using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            var user = await _UserService.GetAllUserAsync();
            return Ok(user);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _UserService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateUser(string first_Name, string last_Name, string username, string email, string password, string address, string phone, string iD_Document, string date, int userTypesId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _UserService.CreateUserAsync(first_Name, last_Name, username, email, password, address, phone, iD_Document, date, userTypesId);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, "User Created successfully.");
        }

        // Validate a user Login
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> ValidateUser(string email, string password)
        {
            if (email == null || password == null) return BadRequest(ModelState);

            // Validate the user
            try
            {
                var isValid = await _UserService.ValidateUserAsync(email, password);
                if (isValid)
                {
                    // Handle successful login  
                    return Ok(new { Message = "Login successful" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }

            // Handle failed login
            return Unauthorized(new { Message = "Invalid Password" });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int id, string first_Name, string last_Name, string username, string email, string password, string address, string phone, string iD_Document, string date, int userTypesId)
        {
            var existingUser = await _UserService.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound();
            try
            {
                await _UserService.UpdateUserAsync(id, first_Name, last_Name, username, email, password, address, phone, iD_Document, date, userTypesId);
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
        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            var user = await _UserService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            await _UserService.SoftDeleteUserAsync(id);
            return NoContent();
        }
    }
}
