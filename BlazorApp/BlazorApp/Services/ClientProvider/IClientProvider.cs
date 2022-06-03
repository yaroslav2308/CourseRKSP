
public interface IClientProvider
{
    Task<List<Client>> GetAll();
    Task<Client> GetOne(int id);
    Task<bool> Add(ClientDTO item);
    Task<Client> Edit(Client item);
    Task<bool> Remove(int id);
}


