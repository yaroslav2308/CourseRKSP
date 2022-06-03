using Microsoft.EntityFrameworkCore;

public class DriverService
{
    private FurnitureStoreContext _context;
    public DriverService(FurnitureStoreContext context)
    {
        _context = context;
    }

    public async Task<Driver?> AddDriver(DriverDTO driver)
    {
        Driver ndriver = new Driver
        {
            name = driver.name,
            phone = driver.phone,
            seniority = driver.seniority
        };
        if (driver.orders.Any())
        {
            ndriver.orders = _context.Orders.ToList().IntersectBy(driver.orders, order => order.id).ToList();
        }
        var result = _context.Drivers.Add(ndriver);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<Driver?> GetDriver(int id)
    {

        var result = _context.Drivers.Include(dr => dr.orders).ThenInclude(order => order.furnitures).FirstOrDefault(driver => driver.id == id);

        return await Task.FromResult(result);
    }

    public async Task<List<Driver>> GetDrivers()
    {
        var result = await _context.Drivers.Include(dr => dr.orders).ThenInclude(order => order.furnitures).ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<Driver?> UpdateDriver(int id, DriverDTO newDriver)
    {
        var driver = await _context.Drivers.Include(driver => driver.orders).FirstOrDefaultAsync(dr => dr.id == id);
        if (driver != null)
        {
            driver.name = newDriver.name;
            driver.phone = newDriver.phone;
            driver.seniority = newDriver.seniority;

            if (newDriver.orders.Any())
            {
                driver.orders = _context.Orders.ToList().IntersectBy(newDriver.orders, order => order.id).ToList();
            }

            _context.Drivers.Update(driver);
            _context.Entry(driver).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return driver;
        }

        return null;
    }

    public async Task<bool> DeleteDriver(int id)
    {
        var driver = await _context.Drivers.FirstOrDefaultAsync(dr => dr.id == id);
        if (driver != null)
        {
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}


