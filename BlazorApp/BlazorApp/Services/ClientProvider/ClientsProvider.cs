using System.Net.Http.Json;
using Newtonsoft.Json;

public class ClientsProvider : IClientProvider
{
    private HttpClient _client;
    public ClientsProvider(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Client>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Client>>("/api/client");
    }

    public async Task<Client> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<Client>($"/api/client/{id}");
    }

    public async Task<bool> Add(ClientDTO item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/client", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Client> Edit(Client item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/client", httpContent);
        Client client = JsonConvert.DeserializeObject<Client>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(client);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/client/${id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }

}


