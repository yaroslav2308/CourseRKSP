using Microsoft.EntityFrameworkCore;

public class ClientService
{
    private FurnitureStoreContext _context;
    public ClientService(FurnitureStoreContext context)
    {
        _context = context;
    }

    public async Task<Client?> AddClient(ClientDTO client)
    {
        Client nclient = new Client
        {
            name = client.name,
            email = client.email,
            phone = client.phone
        };
        if (client.orders.Any())
        {
            nclient.orders =  _context.Orders.ToList().IntersectBy(client.orders, order => order.id).ToList();
        }
        var result = _context.Clients.Add(nclient);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }


    public async Task<Client?> GetClient(int id)
    {

        var result = _context.Clients.Include(cl => cl.orders).ThenInclude(order => order.furnitures).FirstOrDefault(client => client.id == id);

        return await Task.FromResult(result);
    }

    public async Task<List<Client>> GetClients()
    {
        var result = await _context.Clients.Include(cl => cl.orders).ThenInclude(order => order.furnitures).ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<Client?> UpdateClient(int id, ClientDTO newClient)
    {
        var client = await _context.Clients.Include(client => client.orders).FirstOrDefaultAsync(cl => cl.id == id);
        if (client != null)
        {
            client.name = newClient.name;
            client.email = newClient.email;
            client.phone = newClient.phone;

            if (newClient.orders.Any())
            {
                client.orders = _context.Orders.ToList().IntersectBy(newClient.orders, order => order.id).ToList();
            }

            _context.Clients.Update(client);
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return client;
        }

        return null;
    }

    public async Task<bool> DeleteClient(int id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(cl => cl.id == id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }



}

