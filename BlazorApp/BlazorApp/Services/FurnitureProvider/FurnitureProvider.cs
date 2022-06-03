using System.Net.Http.Json;
using Newtonsoft.Json;

public class FurnitureProvider : IFurnitureProvider
{
    private HttpClient _client;
    public FurnitureProvider(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Furniture>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Furniture>>("/api/furniture");
    }

    public async Task<Furniture> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<Furniture>($"/api/furniture/{id}");
    }

    public async Task<bool> Add(Furniture item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/furniture", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Furniture> Edit(Furniture item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/furniture", httpContent);
        Furniture furniture = JsonConvert.DeserializeObject<Furniture>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(furniture);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/furniture/${id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}


