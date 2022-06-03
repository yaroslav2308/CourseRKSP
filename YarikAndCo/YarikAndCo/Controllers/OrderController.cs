using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class OrderController : ControllerBase
{
    private readonly OrderService _context;

    public OrderController(OrderService context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.GetOrder(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return await _context.GetOrders();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Order>> PutOrder(int id, [FromBody] OrderDTO order)
    {
        var result = await _context.UpdateOrder(id, order); 
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder([FromBody] OrderDTO order)
    {
        var result = await _context.AddOrder(order);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _context.DeleteOrder(id);
        if (order)
        {
            return Ok();
        }
        return BadRequest();
    }
}


