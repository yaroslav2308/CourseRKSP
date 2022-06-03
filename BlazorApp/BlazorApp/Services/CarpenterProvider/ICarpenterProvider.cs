
public interface ICarpenterProvider
{
    Task<List<Carpenter>> GetAll();
    Task<Carpenter> GetOne(int id);
    Task<bool> Add(Carpenter item);
    Task<Carpenter> Edit(Carpenter item);
    Task<bool> Remove(int id);
}


