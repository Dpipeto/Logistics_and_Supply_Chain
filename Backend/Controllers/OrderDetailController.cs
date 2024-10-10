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
        public async Task<ActionResult> CreateOrderDetail(string deliveryTime)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _OrderDetailService.CreateOrderDetailAsync(deliveryTime);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }
            return StatusCode(StatusCodes.Status201Created, "Order Detail created succesfully");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderDetail(int id, string deliveryTime)
        {
            var existingOrderDetail = await _OrderDetailService.GetOrderDetailByIdAsync(id);
            if (existingOrderDetail == null)
                return NotFound();
            try
            {
                await _OrderDetailService.UpdateOrderDetailAsync(id, deliveryTime);
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
