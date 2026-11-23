namespace MLZ2026.Core.Tests;

public interface IExternalDataService
{
    Task<TodoItem[]?> GetTodoItems();
}