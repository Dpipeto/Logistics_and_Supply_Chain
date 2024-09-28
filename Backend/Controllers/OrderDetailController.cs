using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _OrderDetailService;

        public OrderDetailController(IOrderDetailService OrderDetailService)
        {
            _OrderDetailService = OrderDetailService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetAllOrderDetail()
        {
            var orderDetail = await _OrderDetailService.GetAllOrderDetailAsync();
            return Ok(orderDetail);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDetail>> GetOrderDetailById(int id)
        {
            var orderDetail = await _OrderDetailService.GetOrderDetailByIdAsync(id);
            if (orderDetail == null)
                return NotFound();

            return Ok(orderDetail);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateOrderDetail([FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _OrderDetailService.CreateOrderDetailAsync(orderDetail);
            return CreatedAtAction(nameof(GetOrderDetailById), new { id = orderDetail.Id }, orderDetail);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderDetail(int id, [FromBody] OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
                return BadRequest();

            var existingOrderDetail = await _OrderDetailService.GetOrderDetailByIdAsync(id);
            if (existingOrderDetail == null)
                return NotFound();

            await _OrderDetailService.UpdateOrderDetailAsync(orderDetail);
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteOrderDetail(int id)
        {
            var orderDetail = await _OrderDetailService.GetOrderDetailByIdAsync(id);
            if (orderDetail == null)
                return NotFound();

            await _OrderDetailService.SoftDeleteOrderDetailAsync(id);
            return NoContent();
        }
    }
}
