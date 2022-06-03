using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class CarpenterController : ControllerBase
{
    private readonly CarpenterService _context;

    public CarpenterController(CarpenterService context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Carpenter>> GetCarpenter(int id)
    {
        var client = await _context.GetCarpenter(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Carpenter>>> GetCarpenters()
    {
        return await _context.GetCarpenters();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Carpenter>> PutCarpenter(int id, [FromBody] CarpenterDTO carpenter)
    {
        var result = await _context.UpdateCarpenter(id, carpenter);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Carpenter>> PostClient([FromBody] CarpenterDTO carpenter)
    {
        var result = await _context.AddCarpenter(carpenter);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarpenter(int id)
    {
        var client = await _context.DeleteCarpenter(id);
        if (client)
        {
            return Ok();
        }
        return BadRequest();
    }
}




