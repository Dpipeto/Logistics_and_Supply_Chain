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
        public async Task<ActionResult> CreateOrderTracking(string date, int orderId, int dealerId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _OrderTrackingService.CreateOrderTrackingAsync(date, orderId, dealerId);
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
        public async Task<IActionResult> UpdateOrderTracking(int id, string date, int orderId, int dealerId)
        {
            var existingOrderTracking = await _OrderTrackingService.GetOrderTrackingByIdAsync(id);
            if (existingOrderTracking == null)
                return NotFound();
            try
            {
                await _OrderTrackingService.UpdateOrderTrackingAsync(id, date, orderId, dealerId);
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
