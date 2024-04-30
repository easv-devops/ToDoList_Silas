using Models;

namespace ToDoList_Front.Clients;

public class ItemsClient
{
    private readonly HttpClient _httpClient;
    
    public ItemsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Item[]> GetItems() 
        => await _httpClient.GetFromJsonAsync<Item[]>("Items") ?? [];
    
    public async Task<Item> GetItem(int id)
        => await _httpClient.GetFromJsonAsync<Item>($"Items/{id}") ?? throw new ArgumentNullException();
    
    public async Task<int> CreateItem(ItemDto item)
    {
        var response = await _httpClient.PostAsJsonAsync("Items", item);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<int>();
    }
    
    public async Task UpdateItem(int id, ItemDto item)
        => await _httpClient.PutAsJsonAsync($"Items/{id}", item);
    
    public async Task DeleteItem(int id)
        => await _httpClient.DeleteAsync($"Items/{id}");
}