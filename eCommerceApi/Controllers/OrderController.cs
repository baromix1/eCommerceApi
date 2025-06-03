using eCommerceApi.DTOs.OrderDTOs;
using eCommerceApi.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto dto)
        {
            try
            {
                var order = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
            }
            catch (ArgumentException)
            {
                return BadRequest(new { error = "Invalid productId." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderDto dto)
        {
            try
            {
                var updatedOrder = await _service.UpdateAsync(id, dto);
                if (updatedOrder == null) return NotFound();
                return Ok(updatedOrder);
            }
            catch (ArgumentException)
            {
                return BadRequest(new { error = "Invalid productId." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
