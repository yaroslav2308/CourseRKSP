
public interface IOrderProvider
{
    Task<List<Order>> GetAll();
    Task<Order> GetOne(int id);
    Task<bool> Add(OrderDTO item);
    Task<Order> Edit(Order item);
    Task<bool> Remove(int id);
}

