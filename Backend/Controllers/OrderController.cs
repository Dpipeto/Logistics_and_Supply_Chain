using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder()
        {
            var order = await _OrderService.GetAllOrderAsync();
            return Ok(order);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _OrderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateOrder(string typeOrder, string packageSender, string packageReceive, string orderValue, string senderAddress, string senderPhone, string senderEmail, int userId, int orderDetailId, int orderStatusTypeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _OrderService.CreateOrderAsync(typeOrder, packageSender, packageReceive, orderValue, senderAddress, senderPhone, senderEmail, userId, orderDetailId, orderStatusTypeId);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }


            return StatusCode(StatusCodes.Status201Created, "Order created succesfully");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrder(int id, string typeOrder, string packageSender, string packageReceive, string orderValue, string senderAddress, string senderPhone, string senderEmail, int userId, int orderDetailId, int orderStatusTypeId)
        {
            var existingOrder = await _OrderService.GetOrderByIdAsync(id);
            if (existingOrder == null)
                return NotFound();

            try
            {
                await _OrderService.UpdateOrderAsync(id, typeOrder, packageSender, packageReceive, orderValue, senderAddress, senderPhone, senderEmail, userId, orderDetailId, orderStatusTypeId);
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
        public async Task<IActionResult> SoftDeleteOrder(int id)
        {
            var order = await _OrderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            await _OrderService.SoftDeleteOrderAsync(id);
            return NoContent();
        }
    }
}
