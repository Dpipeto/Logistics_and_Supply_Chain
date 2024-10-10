using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<ActionResult> CreateOrderTrackingType(string ordertrackingType, int orderTrackingId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _OrderTrackingTypeService.CreateOrderTrackingTypeAsync(ordertrackingType, orderTrackingId);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }


            return StatusCode(StatusCodes.Status201Created, "Order Tracking Type created succesfully");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderTrackingType(int id, string ordertrackingType, int orderTrackingId)
        {
            var existingOrderTrackingType = await _OrderTrackingTypeService.GetOrderTrackingTypeByIdAsync(id);
            if (existingOrderTrackingType == null)
                return NotFound();
            try
            {
                await _OrderTrackingTypeService.UpdateOrderTrackingTypeAsync(id, ordertrackingType, orderTrackingId);
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
