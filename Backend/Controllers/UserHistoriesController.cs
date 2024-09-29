using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserHistoriesController : ControllerBase
    {
        private readonly IUserHistoriesService _userHistoriesService;

        public UserHistoriesController(IUserHistoriesService userHistoriesService)
        {
            _userHistoriesService = userHistoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserHistories>>> GetAllUserHistories()
        {
            var userHistories = await _userHistoriesService.GetAllUserHistoriesAsync();
            return Ok(userHistories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserHistories>> GetUserHistoryById(int id)
        {
            var userHistory = await _userHistoriesService.GetUserHistoryByIdAsync(id);
            if (userHistory == null)
            {
                return NotFound();
            }
            return Ok(userHistory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserHistory(UserHistories userHistory)
        {
            await _userHistoriesService.CreateUserHistoryAsync(userHistory);
            return CreatedAtAction(nameof(GetUserHistoryById), new { id = userHistory.Id }, userHistory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserHistory(int id, UserHistories userHistory)
        {
            if (id != userHistory.Id)
            {
                return BadRequest();
            }

            await _userHistoriesService.UpdateUserHistoryAsync(userHistory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteUserHistory(int id)
        {
            await _userHistoriesService.SoftDeleteUserHistoryAsync(id);
            return NoContent();
        }
    }

}
