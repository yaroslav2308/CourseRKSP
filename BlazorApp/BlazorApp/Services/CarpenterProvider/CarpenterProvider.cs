using System.Net.Http.Json;
using Newtonsoft.Json;

public class CarpenterProvider : ICarpenterProvider
{
    private HttpClient _client;
    public CarpenterProvider(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Carpenter>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Carpenter>>("/api/carpenter");
    }

    public async Task<Carpenter> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<Carpenter>($"/api/carpenter/{id}");
    }

    public async Task<bool> Add(Carpenter item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/carpenter", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Carpenter> Edit(Carpenter item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/carpenter", httpContent);
        Carpenter carpenter = JsonConvert.DeserializeObject<Carpenter>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(carpenter);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/carpenter/${id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}


