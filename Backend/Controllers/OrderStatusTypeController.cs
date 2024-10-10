using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusTypeController : ControllerBase
    {
        private readonly IOrderStatusTypeService _OrderStatusTypeService;

        public OrderStatusTypeController(IOrderStatusTypeService OrderStatusTypeService)
        {
            _OrderStatusTypeService = OrderStatusTypeService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderStatusType>>> GetAllOrderStatusType()
        {
            var orderStatus = await _OrderStatusTypeService.GetAllOrderStatusTypeAsync();
            return Ok(orderStatus);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderStatusType>> GetOrderStatusTypeById(int id)
        {
            var orderStatus = await _OrderStatusTypeService.GetOrderStatusTypeByIdAsync(id);
            if (orderStatus == null)
                return NotFound();

            return Ok(orderStatus);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateOrderStatusType(string orderStatusType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _OrderStatusTypeService.CreateOrderStatusTypeAsync(orderStatusType);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }
            return StatusCode(StatusCodes.Status201Created, "Order Status created succesfully");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderStatusType(int id, string orderStatusType)
        {
            var existingOrderStatusType = await _OrderStatusTypeService.GetOrderStatusTypeByIdAsync(id);
            if (existingOrderStatusType == null)
                return NotFound();

            try
            {
                await _OrderStatusTypeService.UpdateOrderStatusTypeAsync(id, orderStatusType);
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
        public async Task<IActionResult> SoftDeleteOrderStatusType(int id)
        {
            var orderStatus = await _OrderStatusTypeService.GetOrderStatusTypeByIdAsync(id);
            if (orderStatus == null)
                return NotFound();

            await _OrderStatusTypeService.SoftDeleteOrderStatusTypeAsync(id);
            return NoContent();
        }
    }
}
