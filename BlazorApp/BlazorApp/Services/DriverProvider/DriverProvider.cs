using System.Net.Http.Json;
using Newtonsoft.Json;

public class DriverProvider : IDriverProvider
{
    private HttpClient _client;
    public DriverProvider(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Driver>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Driver>>("/api/driver");
    }

    public async Task<Driver> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<Driver>($"/api/driver/{id}");
    }

    public async Task<bool> Add(Driver item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/driver", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Driver> Edit(Driver item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/driver", httpContent);
        Driver driver = JsonConvert.DeserializeObject<Driver>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(driver);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/driver/${id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }

}

