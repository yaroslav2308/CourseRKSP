using Microsoft.EntityFrameworkCore;

public class OrderService
{

    private FurnitureStoreContext _context;
    public OrderService(FurnitureStoreContext context)
    {
        _context = context;
    }

    public async Task<Order?> AddOrder(OrderDTO order)
    {
        Order norder = new Order
        {
            destination = order.destination
  
        };

        if (order.client != null )
        {
            norder.client = _context.Clients.ToList().SingleOrDefault(orderInList => orderInList.id == order.client);
        }

        if (order.carpenter != null)
        {
            norder.carpenter = _context.Carpenters.ToList().SingleOrDefault(orderInList => orderInList.id == order.carpenter);
        }

        if (order.driver != null)
        {
            norder.driver = _context.Drivers.ToList().SingleOrDefault(orderInList => orderInList.id == order.driver);
        }

        if (order.furnitures.Any())
        {
            norder.furnitures = _context.Furnitures.ToList().IntersectBy(order.furnitures, furniture => furniture.id).ToList();
        }
        var result = _context.Orders.Add(norder);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<Order?> GetOrder(int id)
    {

        var result = _context.Orders.Include(or => or.client).Include(or => or.furnitures).FirstOrDefault(order => order.id == id);

        return await Task.FromResult(result);
    }

    public async Task<List<Order>> GetOrders()
    {
        var result = await _context.Orders.Include(or => or.client).Include(or => or.furnitures).ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<Order?> UpdateOrder(int id, OrderDTO newOrder)
    {
        var order = await _context.Orders.Include(order => order.client).Include(order => order.furnitures).FirstOrDefaultAsync(cl => cl.id == id);
        if (order != null)
        {

            if (newOrder.client != null)
            {
                order.client = _context.Clients.ToList().SingleOrDefault(orderInList => orderInList.id == newOrder.client);
            }

            if (newOrder.carpenter != null)
            {
                order.carpenter = _context.Carpenters.ToList().SingleOrDefault(orderInList => orderInList.id == newOrder.carpenter);
            }

            if (newOrder.driver != null)
            {
                order.driver = _context.Drivers.ToList().SingleOrDefault(orderInList => orderInList.id == newOrder.driver);
            }

            if (newOrder.furnitures.Any())
            {
                order.furnitures = _context.Furnitures.ToList().IntersectBy(newOrder.furnitures, furniture => furniture.id).ToList();
            }

            _context.Orders.Update(order);
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return order;
        }

        return null;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(or => or.id == id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }


}

