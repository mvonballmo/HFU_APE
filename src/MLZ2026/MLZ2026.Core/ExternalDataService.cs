using System.Text.Json;

namespace MLZ2026.Core.Tests;

class ExternalDataService : IExternalDataService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ExternalDataService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<TodoItem[]?> GetTodoItems()
    {
        var httpClient = _httpClientFactory.CreateClient();
        
        // Stop restricting to user id = 3
        string userId = "3";
        
        TodoItem[]? todos = await httpClient.GetFromJsonAsync<TodoItem[]>(
            $"https://jsonplaceholder.typicode.com/todos?userId={userId}",
            new JsonSerializerOptions(JsonSerializerDefaults.Web));

        return todos;
    }
}