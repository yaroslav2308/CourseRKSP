using Microsoft.EntityFrameworkCore;

public class CarpenterService
{
    private FurnitureStoreContext _context;
    public CarpenterService(FurnitureStoreContext context)
    {
        _context = context;
    }

    public async Task<Carpenter?> AddCarpenter(CarpenterDTO carpenter)
    {
        Carpenter ncarpenter = new Carpenter
        {
            name = carpenter.name,
            phone = carpenter.phone,
            seniority = carpenter.seniority
        };
        if (carpenter.orders.Any())
        {
            ncarpenter.orders = _context.Orders.ToList().IntersectBy(carpenter.orders, order => order.id).ToList();
        }
        var result = _context.Carpenters.Add(ncarpenter);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<Carpenter?> GetCarpenter(int id)
    {

        var result = _context.Carpenters.Include(ca => ca.orders).ThenInclude(order => order.furnitures).FirstOrDefault(carpenter => carpenter.id == id);

        return await Task.FromResult(result);
    }

    public async Task<List<Carpenter>> GetCarpenters()
    {
        var result = await _context.Carpenters.Include(ca => ca.orders).ThenInclude(order => order.furnitures).ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<Carpenter?> UpdateCarpenter(int id, CarpenterDTO newCarpenter)
    {
        var carpenter = await _context.Carpenters.Include(carpenter => carpenter.orders).FirstOrDefaultAsync(ca => ca.id == id);
        if (carpenter != null)
        {
            carpenter.name = newCarpenter.name;
            carpenter.phone = newCarpenter.phone;
            carpenter.seniority = newCarpenter.seniority;

            if (newCarpenter.orders.Any())
            {
                carpenter.orders = _context.Orders.ToList().IntersectBy(newCarpenter.orders, order => order.id).ToList();
            }

            _context.Carpenters.Update(carpenter);
            _context.Entry(carpenter).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return carpenter;
        }

        return null;
    }

    public async Task<bool> DeleteCarpenter(int id)
    {
        var carpenter = await _context.Carpenters.FirstOrDefaultAsync(ca => ca.id == id);
        if (carpenter != null)
        {
            _context.Carpenters.Remove(carpenter);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}


