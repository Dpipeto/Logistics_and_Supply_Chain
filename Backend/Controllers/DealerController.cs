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
        public async Task<ActionResult> CreateDealer(string orderDate, string deliveryDate, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _DealerService.CreateDealerAsync(orderDate, deliveryDate, userId);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }


            return StatusCode(StatusCodes.Status201Created, "Dealer created succesfully");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDealer(int id, string orderDate, string deliveryDate, int userId)
        {
            var existingDealer = await _DealerService.GetDealerByIdAsync(id);
            if (existingDealer == null)
                return NotFound();

            try
            {
                await _DealerService.UpdateDealerAsync(id, orderDate, deliveryDate, userId);
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
