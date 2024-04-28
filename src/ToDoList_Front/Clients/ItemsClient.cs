using Models;

namespace ToDoList_Front.Clients;

public class ItemsClient
{
    private readonly HttpClient _httpClient;
    
    public ItemsClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://todolist-api:8080/")
        };
    }
    
    public async Task<Item[]> GetItems()
    {
        var items = await _httpClient.GetFromJsonAsync<Item[]>("Items");
        
        if (items == null)
        {
            throw new Exception("No items found");
        }

        return items;
    }
    
    public async Task<Item> GetItem(int id)
    {
        var item = await _httpClient.GetFromJsonAsync<Item>($"Items/{id}");
        
        if (item == null)
        {
            throw new Exception("Item not found");
        }

        return item;
    }
    
    public async Task CreateItem(ItemDTO item)
    {
        var response = await _httpClient.PostAsJsonAsync("Items", item);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to create item");
        }
    }
    
    public async Task UpdateItem(int id, ItemDTO item)
    {
        var response = await _httpClient.PutAsJsonAsync($"Items/{id}", item);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to update item");
        }
    }
    
    public async Task DeleteItem(int id)
    {
        var response = await _httpClient.DeleteAsync($"Items/{id}");
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to delete item");
        }
    }
}