using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class ClientController : ControllerBase
{
    private readonly ClientService _context;

    public ClientController(ClientService context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(int id)
    {
        var client = await _context.GetClient(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        return await _context.GetClients();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Client>> PutClient(int id, [FromBody] ClientDTO client)
    {
        var result = await _context.UpdateClient(id, client);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Client>> PostClient([FromBody] ClientDTO client)
    {
        var result = await _context.AddClient(client);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await _context.DeleteClient(id);
        if (client)
        {
            return Ok();
        }
        return BadRequest();
    }
}

