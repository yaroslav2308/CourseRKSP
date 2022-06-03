
public interface IFurnitureProvider
{
    Task<List<Furniture>> GetAll();
    Task<Furniture> GetOne(int id);
    Task<bool> Add(Furniture item);
    Task<Furniture> Edit(Furniture item);
    Task<bool> Remove(int id);
}


