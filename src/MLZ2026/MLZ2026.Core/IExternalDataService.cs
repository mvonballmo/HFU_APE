namespace MLZ2026.Core;

public interface IExternalDataService
{
    Task<TodoItem[]> GetTodoItems();
}