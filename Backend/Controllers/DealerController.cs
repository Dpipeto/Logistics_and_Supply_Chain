using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly IDealerService _DealerService;

        public DealerController(IDealerService DealerService)
        {
            _DealerService = DealerService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Dealer>>> GetAllDealer()
        {
            var dealer = await _DealerService.GetAllDealerAsync();
            return Ok(dealer);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Dealer>> GetDealerById(int id)
        {
            var dealer = await _DealerService.GetDealerByIdAsync(id);
            if (dealer == null)
                return NotFound();

            return Ok(dealer);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateDealer([FromBody] Dealer dealer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _DealerService.CreateDealerAsync(dealer);
            return CreatedAtAction(nameof(GetDealerById), new { id = dealer.Id }, dealer);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDealer(int id, [FromBody] Dealer dealer)
        {
            if (id != dealer.Id)
                return BadRequest();

            var existingDealer = await _DealerService.GetDealerByIdAsync(id);
            if (existingDealer == null)
                return NotFound();

            await _DealerService.UpdateDealerAsync(dealer);
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteDealer(int id)
        {
            var dealer = await _DealerService.GetDealerByIdAsync(id);
            if (dealer == null)
                return NotFound();

            await _DealerService.SoftDeleteDealerAsync(id);
            return NoContent();
        }
    }
}
