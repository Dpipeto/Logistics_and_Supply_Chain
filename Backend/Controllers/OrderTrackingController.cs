using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTrackingController : ControllerBase
    {
        private readonly IOrderTrackingService _OrderTrackingService;

        public OrderTrackingController(IOrderTrackingService OrderTrackingService)
        {
            _OrderTrackingService = OrderTrackingService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderTracking>>> GetAllOrderTracking()
        {
            var orderTracking = await _OrderTrackingService.GetAllOrderTrackingAsync();
            return Ok(orderTracking);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderTracking>> GetOrderTrackingById(int id)
        {
            var orderTracking = await _OrderTrackingService.GetOrderTrackingByIdAsync(id);
            if (orderTracking == null)
                return NotFound();

            return Ok(orderTracking);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateOrderTracking([FromBody] OrderTracking orderTracking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _OrderTrackingService.CreateOrderTrackingAsync(orderTracking);
            return CreatedAtAction(nameof(GetOrderTrackingById), new { id = orderTracking.Id }, orderTracking);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderTracking(int id, [FromBody] OrderTracking orderTracking)
        {
            if (id != orderTracking.Id)
                return BadRequest();

            var existingOrderTracking = await _OrderTrackingService.GetOrderTrackingByIdAsync(id);
            if (existingOrderTracking == null)
                return NotFound();

            await _OrderTrackingService.UpdateOrderTrackingAsync(orderTracking);
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteOrderTracking(int id)
        {
            var orderTracking = await _OrderTrackingService.GetOrderTrackingByIdAsync(id);
            if (orderTracking == null)
                return NotFound();

            await _OrderTrackingService.SoftDeleteOrderTrackingAsync(id);
            return NoContent();
        }
    }
}
