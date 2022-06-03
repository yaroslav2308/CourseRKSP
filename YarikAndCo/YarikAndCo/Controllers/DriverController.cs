using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class DriverController : ControllerBase
{
    private readonly DriverService _context;

    public DriverController(DriverService context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Driver>> GetDriver(int id)
    {
        var client = await _context.GetDriver(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
    {
        return await _context.GetDrivers();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Driver>> PutDriver(int id, [FromBody] DriverDTO driver)
    {
        var result = await _context.UpdateDriver(id, driver);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Driver>> PostDriver([FromBody] DriverDTO driver)
    {
        var result = await _context.AddDriver(driver);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        var client = await _context.DeleteDriver(id);
        if (client)
        {
            return Ok();
        }
        return BadRequest();
    }
}


