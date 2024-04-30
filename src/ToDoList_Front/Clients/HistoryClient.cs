using Models;

namespace ToDoList_Front.Clients;

public class HistoryClient
{
    private readonly HttpClient _httpClient;
    
    public HistoryClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<History[]> GetHistories() 
        => await _httpClient.GetFromJsonAsync<History[]>("History") ?? [];
    
    public async Task<History> GetHistory(int id)
        => await _httpClient.GetFromJsonAsync<History>($"History/{id}") ?? throw new ArgumentNullException();
    
    public async Task CreateHistory(HistoryDto history)
        => await _httpClient.PostAsJsonAsync("History", history);
    
    public async Task UpdateHistory(int id, HistoryDto history)
        => await _httpClient.PutAsJsonAsync($"History/{id}", history);
    
    public async Task DeleteHistory(int id)
        => await _httpClient.DeleteAsync($"History/{id}");
}