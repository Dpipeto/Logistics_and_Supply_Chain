using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTrackingTypeController : ControllerBase
    {
        private readonly IOrderTrackingTypeService _OrderTrackingTypeService;

        public OrderTrackingTypeController(IOrderTrackingTypeService OrderTrackingTypeService)
        {
            _OrderTrackingTypeService = OrderTrackingTypeService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderTrackingType>>> GetAllOrderTrackingType()
        {
            var orderTrackingType = await _OrderTrackingTypeService.GetAllOrderTrackingTypeAsync();
            return Ok(orderTrackingType);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderTrackingType>> GetOrderTrackingTypeById(int id)
        {
            var orderTrackingType = await _OrderTrackingTypeService.GetOrderTrackingTypeByIdAsync(id);
            if (orderTrackingType == null)
                return NotFound();

            return Ok(orderTrackingType);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateOrderTrackingType([FromBody] OrderTrackingType orderTrackingType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _OrderTrackingTypeService.CreateOrderTrackingTypeAsync(orderTrackingType);
            return CreatedAtAction(nameof(GetOrderTrackingTypeById), new { id = orderTrackingType.Id }, orderTrackingType);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderTrackingType(int id, [FromBody] OrderTrackingType orderTrackingType)
        {
            if (id != orderTrackingType.Id)
                return BadRequest();

            var existingOrderTrackingType = await _OrderTrackingTypeService.GetOrderTrackingTypeByIdAsync(id);
            if (existingOrderTrackingType == null)
                return NotFound();

            await _OrderTrackingTypeService.UpdateOrderTrackingTypeAsync(orderTrackingType);
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteOrderTrackingType(int id)
        {
            var orderTrackingType = await _OrderTrackingTypeService.GetOrderTrackingTypeByIdAsync(id);
            if (orderTrackingType == null)
                return NotFound();

            await _OrderTrackingTypeService.SoftDeleteOrderTrackingTypeAsync(id);
            return NoContent();
        }
    }
}
