using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailHistoriesController : ControllerBase
    {
        private readonly IOrderDetailHistoriesService _OrderDetailHistoriesService;

        public OrderDetailHistoriesController(IOrderDetailHistoriesService OrderDetailHistoriesService)
        {
            _OrderDetailHistoriesService = OrderDetailHistoriesService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDetailHistories>>> GetAllOrderDetailHistories()
        {
            var orderDetailHistories = await _OrderDetailHistoriesService.GetAllOrderDetailHistoriesAsync();
            return Ok(orderDetailHistories);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDetailHistories>> GetOrderDetailHistoriesById(int id)
        {
            var orderDetailHistories = await _OrderDetailHistoriesService.GetOrderDetailHistoriesByIdAsync(id);
            if (orderDetailHistories == null)
                return NotFound();

            return Ok(orderDetailHistories);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateOrderDetailHistories([FromBody] OrderDetailHistories orderDetailHistories)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _OrderDetailHistoriesService.CreateOrderDetailHistoriesAsync(orderDetailHistories);
            return CreatedAtAction(nameof(GetOrderDetailHistoriesById), new { id = orderDetailHistories.Id }, orderDetailHistories);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderDetailHistories(int id, [FromBody] OrderDetailHistories orderDetailHistories)
        {
            if (id != orderDetailHistories.Id)
                return BadRequest();

            var existingOrderDetailHistories = await _OrderDetailHistoriesService.GetOrderDetailHistoriesByIdAsync(id);
            if (existingOrderDetailHistories == null)
                return NotFound();

            await _OrderDetailHistoriesService.UpdateOrderDetailHistoriesAsync(orderDetailHistories);
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteOrderDetailHistories(int id)
        {
            var orderDetailHistories = await _OrderDetailHistoriesService.GetOrderDetailHistoriesByIdAsync(id);
            if (orderDetailHistories == null)
                return NotFound();

            await _OrderDetailHistoriesService.SoftDeleteOrderDetailHistoriesAsync(id);
            return NoContent();
        }
    }
}
