using System.Text.Json;

namespace MLZ2026.Core;

class ExternalDataService : IExternalDataService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ExternalDataService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<TodoItem[]> GetTodoItems()
    {
        var httpClient = _httpClientFactory.CreateClient();
        
        // Stop restricting to user id = 3
        const string userId = "3";
        
        var todos = await httpClient.GetFromJsonAsync<TodoItem[]>(
            $"https://jsonplaceholder.typicode.com/todos?userId={userId}",
            new JsonSerializerOptions(JsonSerializerDefaults.Web));

        return todos ?? throw new InvalidOperationException("Could not retrieve todos.");
    }
}