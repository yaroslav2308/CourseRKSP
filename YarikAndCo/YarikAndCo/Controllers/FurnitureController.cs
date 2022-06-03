using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class FurnitureController : ControllerBase
{
    private readonly FurnitureService _context;

    public FurnitureController(FurnitureService context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Furniture>> GetFurniture(int id)
    {
        var furniture = await _context.GetFurniture(id);

        if (furniture == null)
        {
            return NotFound();
        }

        return furniture;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Furniture>>> GetFurnitures()
    {
        return await _context.GetFurnitures();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Furniture>> PutFurniture(int id, [FromBody] Furniture furniture)
    {
        var result = await _context.UpdateFurniture(id, furniture);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Furniture>> PostFurniture([FromBody] Furniture furniture)
    {
        var result = await _context.AddFurniture(furniture);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFurniture(int id)
    {
        var furniture = await _context.DeleteFurniture(id);
        if (furniture)
        {
            return Ok();
        }
        return BadRequest();
    }
}

