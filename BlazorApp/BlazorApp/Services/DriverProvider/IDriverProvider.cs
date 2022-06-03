
public interface IDriverProvider
{
    Task<List<Driver>> GetAll();
    Task<Driver> GetOne(int id);
    Task<bool> Add(Driver item);
    Task<Driver> Edit(Driver item);
    Task<bool> Remove(int id);
}


